using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using Watermark.Models;
using Watermark.Repository;
using Watermark.Repository.Contracts;
using Watermark.Services;
using Watermark.Services.Contracts;

namespace WatermarkApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.FromLogContext()
            .WriteTo.RollingFile("Logs/{Date}.log")
            .CreateLogger();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public string DefaultConnectionString { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Register DbContext
            services.AddDbContext<WatermarkDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("Default")));

            // Register Services
            services.AddScoped<INotificationsService, NotificationsService>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddSingleton<IEmailSenderService, EmailSenderService>();

            // Register Repositories
            services.AddScoped<INotificationsRepository, NotificationsRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Authentication Setup
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<WatermarkDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Authentication Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Authentication Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // Authentication User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Admin/Account/Login";
                options.LogoutPath = "/Admin/Account/Logout";
                options.AccessDeniedPath = "/Admin/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            // Authentication Routing
            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Admin");
                    options.Conventions.AllowAnonymousToFolder("/Admin/Account");
                    options.Conventions.AuthorizeFolder("/Admin/Account/Manage");
                    options.Conventions.AllowAnonymousToFolder("/Site");
                });          
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}