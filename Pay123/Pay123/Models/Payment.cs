namespace Pay123.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment
    {
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [Key]
        [StringLength(8)]
        public string ReferenceNumber { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string AccountName { get; set; }

        public string OtherDetails { get; set; }

        public decimal Amount { get; set; }

        public decimal? ServiceFee { get; set; }

        public string PPRemarks { get; set; }

        public int MerchantId { get; set; }

        public int StatusId { get; set; }

        [StringLength(450)]
        public string UserId { get; set; }

        [StringLength(50)]
        public string Client { get; set; }

        [StringLength(50)]
        public string Customer { get; set; }

        public string Attachment { get; set; }

        public string ProcessedBy { get; set; }
    }
}
