using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCPay.Models.ViewModels
{
    public class PaymentMerchantViewModel
    {
        public IEnumerable<Merchant> Merchants { get; set; }
        public Payment Payments { get; set; }
    }
}
