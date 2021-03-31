using ABCPay.Data;
using ABCPay.Models;
using ABCPay.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCPay.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentSendController : ControllerBase
    {
        private IPaymentServices paymentServices { get; set; }
        UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;

        public PaymentSendController(IPaymentServices _paymentServices, ApplicationDbContext _db, UserManager<ApplicationUser> _userManager)
        {
            paymentServices = _paymentServices;
            userManager = _userManager;
            db = _db;
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PaymentDto>))]
        public IActionResult GetPaymentSend()
        {
            var paymentSends = paymentServices.GetPaymentSends();

            var paymentDtos = new List<PaymentDto>();

            foreach (var item in paymentSends)
            {
                paymentDtos.Add(new PaymentDto
                {
                    ReferenceNumber = item.ReferenceNumber,
                    Date = item.Date,
                    AccountNumber = item.AccountNumber,
                    AccountName = item.AccountName,
                    OtherDetails = item.OtherDetails,
                    Amount = item.Amount,
                    ServiceFee = item.ServiceFee,
                    PPRemarks = item.PPRemarks,
                    Client = item.Client,
                    Customer = item.Customer,
                    MerchantName = item.MerchantName,
                    StatusName = item.StatusName,
                    UserId = item.UserId,
                    Attachment = item.Attachment
                });
            }

            return Ok(paymentDtos);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(Payment))]
        public IActionResult GetPaymentSend(string id)
        {
            if(!paymentServices.IsPaymentSendExist(id))
            {
                return NotFound();
            }

            var paymentSend = paymentServices.GetPaymentSend(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PaymentDto paymentDto = new PaymentDto()
            {
                ReferenceNumber = paymentSend.ReferenceNumber,
                Date = paymentSend.Date,
                AccountNumber = paymentSend.AccountNumber,
                AccountName = paymentSend.AccountName,
                OtherDetails = paymentSend.OtherDetails,
                Amount = paymentSend.Amount,
                ServiceFee = paymentSend.ServiceFee,
                PPRemarks = paymentSend.PPRemarks,
                Client = paymentSend.Client,
                Customer = paymentSend.Customer,
                MerchantName = paymentSend.MerchantName,
                StatusName = paymentSend.StatusName,
                UserId = paymentSend.UserId,
                Attachment = paymentSend.Attachment
            };

            return Ok(paymentDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdatePaymentSend(string id, [FromBody]Payment paymentSend)
        {
            if (paymentSend == null)
                return BadRequest(ModelState);

            if (id != paymentSend.ReferenceNumber)
                return BadRequest(ModelState);

            if (!paymentServices.IsPaymentSendExist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = userManager.FindByIdAsync(paymentSend.UserId).Result;

            if(user.Balance == 0.00M || user.Balance < 0.00M)
            {
                return BadRequest("Not enough Balance");
            }

            if (paymentSend.StatusId == 3)
            {
                user.Balance = user.Balance - Convert.ToDecimal(paymentSend.Amount + paymentSend.ServiceFee);
                await userManager.UpdateAsync(user);
            }


            if (!paymentServices.UpdatePaymentSend(paymentSend))
            {
                ModelState.AddModelError("", $"Something went wrong updating {paymentSend.AccountNumber} - {paymentSend.AccountName}...");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
