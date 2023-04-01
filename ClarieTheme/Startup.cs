using ClarieTheme.DAL;
using ClarieTheme.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllersWithViews();
            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //});

            //services.AddHttpContextAccessor();
            //services.AddIdentity<AppUser, IdentityRole>(op =>
            //{
            //    op.User.RequireUniqueEmail = true;
            //    op.Password.RequiredLength = 6;
            //    op.Password.RequireNonAlphanumeric = true;
            //    op.Password.RequireDigit = true;
            //    op.Password.RequireLowercase = true;
            //    op.Password.RequireUppercase = true;


            //    op.Lockout.AllowedForNewUsers = true;
            //    op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(20);
            //    op.Lockout.MaxFailedAccessAttempts = 3;
            //}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
            //services.AddScoped<LayoutService>();

            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromDays(100);
            });
            services.AddControllersWithViews();
            services.AddIdentity<AppUser, IdentityRole>(op =>
            {
                op.User.RequireUniqueEmail = true;
                op.Password.RequiredLength = 6;
                op.Password.RequireNonAlphanumeric = true;
                op.Password.RequireDigit = true;
                op.Password.RequireLowercase = true;
                op.Password.RequireUppercase = true;


                op.Lockout.AllowedForNewUsers = true;
                op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(20);
                op.Lockout.MaxFailedAccessAttempts = 3;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}"
                 );
            });
        }
    }
}
