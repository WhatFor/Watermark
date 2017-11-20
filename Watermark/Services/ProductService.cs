using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watermark.Models.Products;
using Watermark.Models.Site;
using Watermark.Services.Contracts;

namespace Watermark.Services
{
    public class ProductService : IProductService
    {
        private readonly WatermarkDbContext DbContext;

        public ProductService(WatermarkDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Task<List<Product>> GetAllProducts()
        {
            return Task.FromResult(DbContext.Products.ToList());
        }

        public async Task<Product> CreateProduct(Product product)
        {
            DbContext.Add(product);
            await DbContext.SaveChangesAsync();
            return product;
        }
    }
}