using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ABCPay.Models
{
    public class Merchant
    {
        [Column("MerchantId")]
        public int Id { get; set; }

        [StringLength(100)]
        [Column("MerchantName")]
        public string Name { get; set; }
    }
}
