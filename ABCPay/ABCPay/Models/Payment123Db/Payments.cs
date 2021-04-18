using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ABCPay.Models.Payment123Db
{
    public partial class Payments
    {
        public DateTime Date { get; set; }
        public string ReferenceNumber { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string OtherDetails { get; set; }
        public decimal Amount { get; set; }
        public decimal? ServiceFee { get; set; }
        public string Ppremarks { get; set; }
        public int MerchantId { get; set; }
        public int StatusId { get; set; }
        public string UserId { get; set; }
        public string Client { get; set; }
        public string Customer { get; set; }
        public string Attachment { get; set; }
        public string ProcessedBy { get; set; }

        public virtual Merchants Merchant { get; set; }
        public virtual Statuses Status { get; set; }
    }
}
