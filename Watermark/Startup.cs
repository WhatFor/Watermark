using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Watermark.Extensions;
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
            DefaultConnectionString = BuildConnectionString();
        }

        public IConfiguration Configuration { get; }

        public string DefaultConnectionString { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Register Services
            services.AddScoped<IProductService, ProductService>();

            // Register Repositories
            services.AddScoped<IProductRepository, ProductRepository>(builder => new ProductRepository(DefaultConnectionString));
            
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

            app.EnsureDbCreated(Configuration.GetValue<string>("DefaultDatabaseConfiguration:Server"),
                                Configuration.GetValue<string>("DefaultDatabaseConfiguration:DatabaseName"),
                                Configuration.GetValue<bool>("DefaultDatabaseConfiguration:TrustedConnection"),
                                Configuration.GetValue<bool>("DefaultDatabaseConfiguration:MultipleActiveResultSets"));

            app.MigrateDatabase(DefaultConnectionString, env.ContentRootPath);

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }

        private string BuildConnectionString()
        {
            return $@"Data Source={Configuration.GetValue<string>("DefaultDatabaseConfiguration:Server")};
                      Initial Catalog={Configuration.GetValue<string>("DefaultDatabaseConfiguration:DatabaseName")};
                      Trusted_Connection={Configuration.GetValue<bool>("DefaultDatabaseConfiguration:TrustedConnection")};
                      MultipleActiveResultSets={Configuration.GetValue<bool>("DefaultDatabaseConfiguration:MultipleActiveResultSets")}";
        }
    }
}