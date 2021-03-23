using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ABCPay.Models
{
    public class Payment
    {
        [Column("PaymentId")]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }


        [Display(Name = "Reference Number")]
        [Required]
        public string ReferenceNumber { get; set; }


        [Display(Name = "Account Number")]
        [Required]
        public string AccountNumber { get; set; }


        [Display(Name = "Account Name")]
        [StringLength(20)]
        [Required]
        public string AccountName { get; set; }


        [Display(Name = "Other Details")]
        public string OtherDetails { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }


        [Display(Name = "Service Fee")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ServiceFee { get; set; }


        [Display(Name = "Payment Remarks")]
        public string PPRemarks { get; set; }


        [Display(Name = "Merchant")]
        public int MerchantId { get; set; }
        [ForeignKey("MerchantId")]
        public Merchant Merchant { get; set; }


        [Display(Name = "Status")]
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }


        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
