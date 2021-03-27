using ABCPay.Data;
using ABCPay.Models;
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
        public ICollection<Payment> GetPaymentSends()
        {
            return db.Payments.OrderBy(p => p.Date).ToList();
        }

        public Payment GetPaymentSend(string id)
        {
            return db.Payments.Where(p => p.ReferenceNumber == id).FirstOrDefault();
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


        //public bool IsPaymentExist(string id)
        //{
        //    return db.Payments.Any(p => p.ReferenceNumber == id);
        //}

        //public bool UpdatePayment(Payment payment)
        //{
        //    db.Update(payment);

        //    return SavePaymentSend();
        //}

       
    }
}
