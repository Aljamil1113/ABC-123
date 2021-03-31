using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ABCPay.Models
{
    public class PaymentDto
    {
        [Key]
        [Required]
        [StringLength(8)]
        [Display(Name = "Reference Number")]
        public string ReferenceNumber { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [StringLength(50)]
        public string Client { get; set; }

        [StringLength(50)]
        public string Customer { get; set; }


        [Display(Name = "Merchant")]
        public string MerchantName { get; set; }


        [Display(Name = "Account Number")]
        [Required]
        public string AccountNumber { get; set; }


        [Display(Name = "Account Name")]
        [StringLength(50)]
        [Required]
        public string AccountName { get; set; }


        [Display(Name = "Other Details")]
        public string OtherDetails { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }


        [Display(Name = "Service Fee")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ServiceFee { get; set; }


        [Display(Name = "Status")]
        public string StatusName { get; set; }


        [Display(Name = "Payment Remarks")]
        public string PPRemarks { get; set; }    

        public string UserId { get; set; }

        public string Attachment { get; set; }
    }
}
