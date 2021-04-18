using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ABCPay.Models.Payment123Db
{
    public partial class Payment123Context : DbContext
    {
        public Payment123Context()
        {
        }

        public Payment123Context(DbContextOptions<Payment123Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Merchants> Merchants { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<PaymentsStatusMerchant> PaymentsStatusMerchant { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //warning To protect potentially sensitive information in your connection string, you should move it out of 
                //source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-KGQRUI1;Database=Payment123;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Merchants>(entity =>
            {
                entity.HasKey(e => e.MerchantId);

                entity.Property(e => e.MerchantName).HasMaxLength(100);
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.ReferenceNumber);

                entity.Property(e => e.ReferenceNumber).HasMaxLength(8);

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.AccountNumber).IsRequired();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.Customer).HasMaxLength(50);

                entity.Property(e => e.Ppremarks).HasColumnName("PPRemarks");

                entity.Property(e => e.ServiceFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.MerchantId);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.StatusId);
            });

            modelBuilder.Entity<PaymentsStatusMerchant>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PaymentsStatusMerchant");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.AccountNumber).IsRequired();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.Customer).HasMaxLength(50);

                entity.Property(e => e.MerchantName).HasMaxLength(100);

                entity.Property(e => e.Ppremarks).HasColumnName("PPRemarks");

                entity.Property(e => e.ReferenceNumber)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.ServiceFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            modelBuilder.Entity<Statuses>(entity =>
            {
                entity.HasKey(e => e.StatusId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__tblUsers__C9F2845706348CB8");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
