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
        [ProducesResponseType(200, Type = typeof(IEnumerable<PaymentSend>))]
        public IActionResult GetPaymentSend()
        {
            var paymentSends = paymentServices.GetPaymentSends();

            return Ok(paymentSends);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(PaymentSend))]
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

            return Ok(paymentSend);
        }

    }
}
