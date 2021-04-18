using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Pay123.Models;
using System.Linq;

namespace Pay123.Data
{
    public partial class Pay123Db : DbContext
    {
        public Pay123Db()
            : base("name=Pay123Db")
        {
        }

        public virtual DbSet<Merchant> Merchants { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<PaymentsStatusMerchant> PaymentViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
