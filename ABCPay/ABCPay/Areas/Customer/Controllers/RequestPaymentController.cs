using ABCPay.Data;
using ABCPay.Models;
using ABCPay.Models.Payment123Db;
using ABCPay.Models.ViewModels;
using ABCPay.Models.Views;
using ABCPay.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ABCPay.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class RequestPaymentController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly Payment123Context backDb;
        private int PageSize = 10;

        public int MyProperty { get; set; }

        [BindProperty]
        public PaymentMerchantViewModel PaymentVM { get; set; }
        public RequestPaymentController(ApplicationDbContext _db, Payment123Context _backDb)
        {
            db = _db;
            backDb = _backDb;
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
                PaymentSs = new List<PaymentMS>()
            };

            StringBuilder param = new StringBuilder();

            param.Append("/Customer/RequestPayment?productPage=:");

            RequestPaymentVM.PaymentSs = db.PaymentMSs.Where(p => p.UserId == claim.Value).ToList();

            if (RequestPaymentVM.PaymentSs == null)
            {
                return View();
            }

            var count = RequestPaymentVM.PaymentSs.Count;

            RequestPaymentVM.PaymentSs = RequestPaymentVM.PaymentSs.OrderBy(p => p.Date)
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
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PaymentVM.Payments = await db.Payments.Where(p => p.ReferenceNumber == id).SingleOrDefaultAsync();

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

            PaymentVM.Payments.Client = client;
            PaymentVM.Payments.Customer = user.FirstName + " " + user.LastName;


            if (PaymentVM.Payments.ReferenceNumber == null)
            {
                i++;
                PaymentVM.Payments.ReferenceNumber = GetRandomString(i);
                PaymentVM.Payments.UserId = claim.Value;
                PaymentVM.Payments.Date = DateTime.Now;
                PaymentVM.Payments.StatusId = 1;

                db.Payments.Add(PaymentVM.Payments);

                await backDb.Database.ExecuteSqlRawAsync("exec spAddPayment {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}",
                    PaymentVM.Payments.ReferenceNumber, PaymentVM.Payments.Date, PaymentVM.Payments.AccountNumber, PaymentVM.Payments.AccountName,
                    PaymentVM.Payments.OtherDetails, PaymentVM.Payments.Amount, PaymentVM.Payments.ServiceFee, PaymentVM.Payments.PPRemarks, client,
                    user.FirstName + " " + user.LastName, PaymentVM.Payments.MerchantId, PaymentVM.Payments.StatusId, PaymentVM.Payments.Attachment,
                    PaymentVM.Payments.ProcessedBy);
            }

            else
            {
                db.Payments.Update(PaymentVM.Payments);

                await backDb.Database.ExecuteSqlRawAsync("exec spEditPayment {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}",
                    PaymentVM.Payments.ReferenceNumber, PaymentVM.Payments.Date, PaymentVM.Payments.AccountNumber, PaymentVM.Payments.AccountName,
                    PaymentVM.Payments.OtherDetails, PaymentVM.Payments.Amount, PaymentVM.Payments.ServiceFee, PaymentVM.Payments.PPRemarks, client,
                    user.FirstName + " " + user.LastName, PaymentVM.Payments.MerchantId, PaymentVM.Payments.StatusId, PaymentVM.Payments.Attachment,
                    PaymentVM.Payments.ProcessedBy);
            }

            await db.SaveChangesAsync();
            return RedirectToAction("Index", "RequestPayment");
        }

        [HttpGet]
        public IActionResult Import()
        {
            return View("ImportForm", PaymentVM);
        }

        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            var listPayments = new List<Payment>();

            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var user = await db.ApplicationUsers.Where(a => a.Id == claim.Value).SingleOrDefaultAsync();

            const string client = "ABC Pay";
            string customer = user.FirstName + " " + user.LastName;


            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using(var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        listPayments.Add(new Payment
                        {
                            ReferenceNumber = GetRandomString(row),
                            Date = DateTime.Now,
                            Client = client,
                            Customer = customer,
                            UserId = claim.Value,
                            MerchantId = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                            AccountNumber = worksheet.Cells[row, 2].Value.ToString(),
                            AccountName = worksheet.Cells[row, 3].Value.ToString(),
                            OtherDetails = worksheet.Cells[row, 4].Value.ToString(),
                            Amount = Convert.ToDecimal(worksheet.Cells[row, 5].Value),
                            StatusId = Convert.ToInt32(worksheet.Cells[row, 6].Value),
                            Attachment = null,
                            ProcessedBy = null
                        });

                    }
                }
            }

            if(ModelState.IsValid)
            {
                db.Payments.AddRange(listPayments);


                foreach (Payment payment in listPayments)
                {
                    await backDb.Database.ExecuteSqlRawAsync("exec spAddPayment {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}",
                    payment.ReferenceNumber, payment.Date, payment.AccountNumber, payment.AccountName, payment.OtherDetails, payment.Amount, payment.ServiceFee, 
                    payment.PPRemarks, payment.Client, payment.Customer, payment.MerchantId, payment.StatusId, payment.Attachment, payment.ProcessedBy);
                }


                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index", "RequestPayment");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PaymentVM.Payments = await db.Payments.Where(p => p.ReferenceNumber == id).SingleOrDefaultAsync();

            if (PaymentVM.Payments == null)
            {
                return NotFound();
            }

            return PartialView("DeletePayment", PaymentVM.Payments);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePayment(string id)
        {
            var payment = await db.Payments.Where(p => p.ReferenceNumber == id).SingleOrDefaultAsync();
            db.Payments.Remove(payment);
            await backDb.Database.ExecuteSqlRawAsync("exec spDeletePayment {0}", payment.ReferenceNumber);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "RequestPayment");
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        public async Task<IActionResult> DownloadFile(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
    }
}
