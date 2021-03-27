using Pay123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay123.Services
{
    interface IRestService
    {
        Task<IEnumerable<Payment>> GetPayments();

        void EditPaymentSend(Payment payment);
    }
}
