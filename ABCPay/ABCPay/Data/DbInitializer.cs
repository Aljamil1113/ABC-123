using ABCPay.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCPay.Data
{
    public class DbInitializer : IDbInitializer
    {
        public ApplicationDbContext db { get; set; }
        public UserManager<ApplicationUser> userManager { get; set; }
        public DbInitializer(ApplicationDbContext _db, UserManager<ApplicationUser> _userManager)
        {
            db = _db;
            userManager = _userManager;
        }

        public void Initializer()
        {
            if (db.Database.GetPendingMigrations().Count() > 0)
            {
                db.Database.Migrate();
            }

            userManager.CreateAsync(new ApplicationUser
            {
                UserName = "admin@abc.com",
                Email = "admin@abc.com",
                FirstName = "Admin",
                LastName = "Admin",
                MiddleName = "Admin",
                Balance = 10000.00M,
                EmailConfirmed = true
            }, "Admin123*").GetAwaiter().GetResult();

            userManager.CreateAsync(new ApplicationUser
            {
                UserName = "al@abc.com",
                Email = "al@abc.com",
                FirstName = "Al Jamil",
                LastName = "Arazas",
                MiddleName = "Lopez",
                Balance = 10000.00M,
                EmailConfirmed = true
            }, "Admin123*").GetAwaiter().GetResult();
        }
    }
}
