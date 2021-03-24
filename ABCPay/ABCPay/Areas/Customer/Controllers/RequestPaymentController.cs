﻿using ABCPay.Data;
using ABCPay.Models;
using ABCPay.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ABCPay.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class RequestPaymentController : Controller
    {
        private readonly ApplicationDbContext db;

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
        public IActionResult Index()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var payments = db.Payments.Where(p => p.UserId == claim.Value).Include(m => m.Merchant)
                .Include(s => s.Status).ToList();

            if (payments == null)
            {
                return View();
            }

            return View(payments);
        }

        private string GetRandomString(int seed)
        {
            //use the following string to control your set of alphabetic characters to choose from
            //for example, you could include uppercase too
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";

            // Random is not truly random,
            // so we try to encourage better randomness by always changing the seed value
            Random rnd = new Random((seed + DateTime.Now.Millisecond));

            // basic 5 digit random number
            string result = rnd.Next(10000, 99999).ToString();

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

            int i = 0;
            
            if(PaymentVM.Payments.Id == 0)
            {
                i++;
                PaymentVM.Payments.ReferenceNumber = GetRandomString(i);
                PaymentVM.Payments.UserId = claim.Value;
                PaymentVM.Payments.Date = DateTime.Now;
                PaymentVM.Payments.StatusId = 1;

                db.Payments.Add(PaymentVM.Payments);
            }

            else
            {
                db.Payments.Update(PaymentVM.Payments);
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
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "RequestPayment");
        }
    }
}