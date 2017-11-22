using Microsoft.EntityFrameworkCore;
using Watermark.Models.Products;

namespace Watermark.Repository
{
    public class WatermarkDbContext : DbContext
    {
        public WatermarkDbContext(DbContextOptions<WatermarkDbContext> options) : base(options)
        {

        }

        // Create Domain Model DbSets
        public DbSet<Product> Products { get; set; }
    }
}