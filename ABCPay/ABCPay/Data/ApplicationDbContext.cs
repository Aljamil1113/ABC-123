
using System;
using System.Collections.Generic;
using System.Text;
using ABCPay.Models;
using ABCPay.Models.Views;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ABCPay.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<PaymentMS> PaymentMSs { get; set; }

    }

}
