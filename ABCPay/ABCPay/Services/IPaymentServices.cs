using ABCPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCPay.Services
{
    public interface IPaymentServices
    {
        ICollection<Payment> GetPaymentSends();
        Payment GetPaymentSend(string id);
        bool IsPaymentSendExist(string id);

        bool UpdatePaymentSend(Payment paymentSend);
        bool SavePaymentSend();

        //bool IsPaymentExist(string id);
        //bool UpdatePayment(Payment payment);
    }
}
