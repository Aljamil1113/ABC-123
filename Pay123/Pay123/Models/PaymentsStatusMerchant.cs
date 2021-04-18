namespace Pay123.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentsStatusMerchant")]
    public partial class PaymentsStatusMerchant
    {
        [Column(Order = 0, TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string ReferenceNumber { get; set; }

        [StringLength(100)]
        public string MerchantName { get; set; }

        [StringLength(50)]
        public string Client { get; set; }

        [StringLength(50)]
        public string Customer { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AccountNumber { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string AccountName { get; set; }

        public string OtherDetails { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal Amount { get; set; }

        public decimal? ServiceFee { get; set; }

        public string PPRemarks { get; set; }

        public string StatusName { get; set; }

        [StringLength(450)]
        public string UserId { get; set; }
        public string Attachment { get; set; }


    }
}
