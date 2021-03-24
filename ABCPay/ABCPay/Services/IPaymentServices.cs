using ABCPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCPay.Services
{
    public interface IPaymentServices
    {
        ICollection<PaymentSend> GetPaymentSends();
        PaymentSend GetPaymentSend(string id);
        bool IsPaymentSendExist(string id);
    }
}
