using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Watermark.Models;
using Watermark.Models.Admin.Configuration;
using Watermark.Models.Admin.Notifications;
using Watermark.Models.Products;

namespace Watermark.Repository
{
    public class WatermarkDbContext : IdentityDbContext<ApplicationUser>
    {
        public WatermarkDbContext(DbContextOptions<WatermarkDbContext> options) : base(options)
        {

        }

        // Create Domain Model DbSets
        public DbSet<Product> Products { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<ProductCategory> ProductCategory { get; set; }

        public DbSet<Configuration> Configuration { get; set; }
    }
}