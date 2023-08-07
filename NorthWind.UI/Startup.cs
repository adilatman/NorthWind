using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NorthWind.CORE.Context;
using NorthWind.DAL.Concrete;
using NorthWind.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<MyDbContext>(a => a.UseSqlServer(Configuration.GetConnectionString("MyConn")));
            services.AddScoped<ICategoryDAL,CategoryDAL>();
            services.AddScoped<ICustomerDAL,CustomerDAL>();
            services.AddScoped<IEmployeeDAL,EmployeeDAL>();
            services.AddScoped<IOrderDAL,OrderDAL>();
            services.AddScoped<IOrderDetailDAL,OrderDetailDAL>();
            services.AddScoped<IProductDAL,ProductDAL>();
            services.AddScoped<IShipperDAL,ShipperDAL>();
            services.AddScoped<ISupplierDAL,SupplierDAL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
