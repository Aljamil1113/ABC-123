using ABCPay.Data;
using ABCPay.Models;
using ABCPay.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ABCPay.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class RequestPaymentController : Controller
    {
        private readonly ApplicationDbContext db;
        private int PageSize = 3;

        [BindProperty]
        public PaymentMerchantViewModel PaymentVM { get; set; }
        public RequestPaymentController(ApplicationDbContext _db)
        {
            db = _db;
            PaymentVM = new PaymentMerchantViewModel()
            {
                Merchants = db.Merchants.ToList(),
                Payments = new Payment()
            };
        }

        [HttpGet]
        public IActionResult Index(int productPage = 1)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            RequestPaymentViewModel RequestPaymentVM = new RequestPaymentViewModel()
            {
                Payments = new List<Payment>()
            };

            StringBuilder param = new StringBuilder();

            param.Append("/Customer/RequestPayment?productPage=:");

            RequestPaymentVM.Payments = db.Payments.Where(p => p.UserId == claim.Value).Include(m => m.Merchant)
                .Include(s => s.Status).ToList();

            if (RequestPaymentVM.Payments == null)
            {
                return View();
            }

            var count = RequestPaymentVM.Payments.Count;

            RequestPaymentVM.Payments = RequestPaymentVM.Payments.OrderBy(p => p.Date)
                .Skip((productPage - 1) * PageSize).Take(PageSize).ToList();

            RequestPaymentVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = count,
                urlParam = param.ToString()
            };

            return View(RequestPaymentVM);
        }

        private string GetRandomString(int seed)
        {
            //use the following string to control your set of alphabetic characters to choose from
            //for example, you could include uppercase too
            const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // Random is not truly random,
            // so we try to encourage better randomness by always changing the seed value
            Random rnd = new Random((seed + DateTime.Now.Millisecond));

            // basic 5 digit random number
            string result = rnd.Next(10000000, 99999999).ToString();

            // single random character in ascii range a-z
            string alphaChar = alphabet.Substring(rnd.Next(0, alphabet.Length - 1), 1);

            // random position to put the alpha character
            int replacementIndex = rnd.Next(0, (result.Length - 1));
            result = result.Remove(replacementIndex, 1).Insert(replacementIndex, alphaChar);

            return result;
        }
        
        [HttpGet]
        public IActionResult New()
        {
           return View("PaymentForm", PaymentVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PaymentVM.Payments = await db.Payments.FindAsync(id);

            if (PaymentVM.Payments == null)
            {
                return NotFound();
            }
            return View("PaymentForm", PaymentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var user = await db.ApplicationUsers.Where(a => a.Id == claim.Value).SingleOrDefaultAsync();

            int i = 0;
            const string client = "ABC Pay";
            
            if(PaymentVM.Payments.Id == 0)
            {
                i++;
                PaymentVM.Payments.ReferenceNumber = GetRandomString(i);
                PaymentVM.Payments.UserId = claim.Value;
                PaymentVM.Payments.Date = DateTime.Now;
                PaymentVM.Payments.StatusId = 1;

                db.Payments.Add(PaymentVM.Payments);

                await db.Database.ExecuteSqlRawAsync("exec AddPaymentSend {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}",
                    PaymentVM.Payments.ReferenceNumber, PaymentVM.Payments.Date, PaymentVM.Payments.AccountNumber, PaymentVM.Payments.AccountName,
                    PaymentVM.Payments.OtherDetails, PaymentVM.Payments.Amount, PaymentVM.Payments.ServiceFee, PaymentVM.Payments.PPRemarks, client,
                    user.FirstName + " " + user.LastName, PaymentVM.Payments.MerchantId, PaymentVM.Payments.StatusId);
            }

            else
            {
                db.Payments.Update(PaymentVM.Payments);

                await db.Database.ExecuteSqlRawAsync("exec EditPaymentSend {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}",
                    PaymentVM.Payments.ReferenceNumber, PaymentVM.Payments.Date, PaymentVM.Payments.AccountNumber, PaymentVM.Payments.AccountName,
                    PaymentVM.Payments.OtherDetails, PaymentVM.Payments.Amount, PaymentVM.Payments.ServiceFee, PaymentVM.Payments.PPRemarks, client,
                    user.FirstName + " " + user.LastName, PaymentVM.Payments.MerchantId, PaymentVM.Payments.StatusId);
            }

            await db.SaveChangesAsync();
            return RedirectToAction("Index", "RequestPayment");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            PaymentVM.Payments = await db.Payments.FindAsync(id);

            if(PaymentVM.Payments == null)
            {
                return NotFound();
            }

            return PartialView("_DeleteEmployeePartial", PaymentVM.Payments);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var payment = await db.Payments.FindAsync(id);
            db.Payments.Remove(payment);
            await db.Database.ExecuteSqlRawAsync("exec DeletePaymentSend {0}", payment.ReferenceNumber);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "RequestPayment");
        }
    }
}
