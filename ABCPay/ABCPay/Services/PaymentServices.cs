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
        public ICollection<PaymentSend> GetPaymentSends()
        {
            return db.PaymentSends.OrderBy(p => p.Date).ToList();
        }

        public PaymentSend GetPaymentSend(string id)
        {
            return db.PaymentSends.Where(p => p.ReferenceNumber == id).FirstOrDefault();
        }

        public bool IsPaymentSendExist(string id)
        {
            return db.PaymentSends.Any(p => p.ReferenceNumber == id);
        }
    }
}
