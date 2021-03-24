using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCPay.Models.ViewModels
{
    public class RequestPaymentViewModel
    {
        public List<Payment> Payments { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
