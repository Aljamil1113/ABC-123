using ABCPay.Data;
using ABCPay.Models;
using ABCPay.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCPay.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly ApplicationDbContext db;

        public PaymentServices(ApplicationDbContext _db)
        {
            db = _db;
        }
        public ICollection<PaymentMS> GetPaymentSends()
        {
            return db.PaymentMSs.OrderBy(p => p.Date).ToList();
        }

        public PaymentMS GetPaymentSend(string id)
        {
            return db.PaymentMSs.Where(p => p.ReferenceNumber == id).FirstOrDefault();
        }

        public bool IsPaymentSendExist(string id)
        {
            return db.Payments.Any(p => p.ReferenceNumber == id);
        }

        public bool SavePaymentSend()
        {
            var payment = db.SaveChanges();

            return payment >= 0 ? true : false;
        }

        public bool UpdatePaymentSend(Payment paymentSend)
        {
            db.Update(paymentSend);

            return SavePaymentSend();
        }       
    }
}
