using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryRecord_Core_3_1.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext _context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

            _context.Database.Migrate();

            if (!_context.Vendors.Any())
            {
                _context.Vendors.AddRange(
                    new Vendor
                    {
                        Name = "GFS"
                    },
                    new Vendor
                    {
                        Name = "Prodex"
                    },
                    new Vendor
                    {
                        Name = "Kariba"
                    },
                    new Vendor
                    {
                        Name = "World Meat"
                    },                  
                    new Vendor
                    {
                        Name = "Westons"
                    },
                    new Vendor
                    {
                        Name = "Canada Bread"
                    },
                    new Vendor
                    {
                        Name = "Natrel"
                    },
                    new Vendor
                    {
                        Name = "Silversteins"
                    },
                    new Vendor
                    {
                        Name = "F.S.M. Exp"
                    }
                );

                _context.SaveChanges();
            }
        }
    }
}
