using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryRecord_Core_3_1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Receiver> Receivers { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<VendorList> VendorLists { get; set; }

        public DbSet<FoodCondition> FoodConditions { get; set; }

        public DbSet<Detail> Details { get; set; }

        //public DbSet<Signature> Signatures { get; set; }

    }
}
