using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using LocalizaCS.Views;
using LocalizaCS.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LocalizaCS.Data;
using Microsoft.IdentityModel;

namespace LocalizaCS
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
            var connection = Configuration.GetConnectionString("LocalizaDatabase");
            services.AddDbContext<LocalizaCSContext>(options => options.UseSqlServer(connection));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                                                       .AddEntityFrameworkStores<LocalizaCSContext>()
                                                       .AddDefaultTokenProviders();

            services.AddControllersWithViews();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");
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

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
