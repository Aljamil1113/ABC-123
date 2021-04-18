using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ABCPay.Models.Payment123Db
{
    public partial class Merchants
    {
        public Merchants()
        {
            Payments = new HashSet<Payments>();
        }

        public int MerchantId { get; set; }
        public string MerchantName { get; set; }

        public virtual ICollection<Payments> Payments { get; set; }
    }
}
