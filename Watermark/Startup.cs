using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
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
            services.AddScoped<IProductService, ProductService>();

            // Register Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            
            // .NET Core
            services.AddMvc();
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}