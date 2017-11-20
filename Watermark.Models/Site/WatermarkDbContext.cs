using Microsoft.EntityFrameworkCore;
using Watermark.Models.Products;

namespace Watermark.Models.Site
{
    public class WatermarkDbContext : DbContext
    {
        public WatermarkDbContext(DbContextOptions<WatermarkDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
