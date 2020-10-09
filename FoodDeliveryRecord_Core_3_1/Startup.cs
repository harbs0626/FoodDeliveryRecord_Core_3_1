using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FoodDeliveryRecord_Core_3_1.Models;
using FoodDeliveryRecord_Core_3_1.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryRecord_Core_3_1
{
    public class Startup
    {
        public IConfiguration _Configuration { get; }

        public Startup(IConfiguration _configuration)
        {
            this._Configuration = _configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(this._Configuration["ConnectionStrings:FoodDeliveryDBConn"]));

            services.AddMvc(options => options.EnableEndpointRouting = false);
            
            services.AddTransient<IRecordRepository, EFRecordRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();

            SeedData.EnsurePopulated(app);
        }
    }
}
