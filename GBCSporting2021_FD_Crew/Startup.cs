using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_FD_Crew.Models;

namespace GBCSporting2021_FD_Crew
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
            services.AddMemoryCache();
            services.AddSession();

            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddDbContext<SportsProContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("SportsProContext")));

            services.AddRouting(options => {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = false;
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Homepage index method - route
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // Products routes

                endpoints.MapControllerRoute(
                    name: "product",
                    pattern: "{controller=Product}/{action=List}/{id?}");

                // Technicians routes

                endpoints.MapControllerRoute(
                    name: "technician",
                    pattern: "{controller=Technician}/{action=List}/{id?}");



                // Customers routes

                endpoints.MapControllerRoute(
                    name: "customer",
                    pattern: "{controller=Customer}/{action=List}/{id?}");



                // Incidents routes

                endpoints.MapControllerRoute(
                    name: "incident",
                    pattern: "{controller=Incident}/{action=List}/{id?}");


                // Tech Incidents routes

                endpoints.MapControllerRoute(
                   name: "techincident",
                   pattern: "{controller=TechIncident}/{action=Get}/{id?}");


                // Registration route

                endpoints.MapControllerRoute(
                    name: "registration",
                pattern: "{controller=Registration}/{action=List}/{id?}");


            });
        }
    }
}
