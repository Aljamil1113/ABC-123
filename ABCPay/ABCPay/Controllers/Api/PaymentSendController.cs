using ABCPay.Models;
using ABCPay.Services;
using Microsoft.AspNetCore.Http;
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

        public PaymentSendController(IPaymentServices _paymentServices)
        {
            paymentServices = _paymentServices;
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
                    MerchantId = item.MerchantId,
                    StatusId = item.StatusId,
                    UserId = item.UserId
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
                MerchantId = paymentSend.MerchantId,
                StatusId = paymentSend.StatusId,
                UserId = paymentSend.UserId
            };

            return Ok(paymentDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdatePaymentSend(string id, [FromBody]Payment paymentSend)
        {
            if (paymentSend == null)
                return BadRequest(ModelState);

            if (id != paymentSend.ReferenceNumber)
                return BadRequest(ModelState);

            if (!paymentServices.IsPaymentSendExist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!paymentServices.UpdatePaymentSend(paymentSend))
            {
                ModelState.AddModelError("", $"Something went wrong updating {paymentSend.AccountNumber} - {paymentSend.AccountName}...");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
