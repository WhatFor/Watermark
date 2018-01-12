using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watermark.Models.Products;
using Watermark.Repository.Contracts;

namespace Watermark.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly WatermarkDbContext DbContext;

        public ProductRepository(WatermarkDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return DbContext.Products
                .Include(m => m.ProductName)
                .Include(m => m.ProductSKU)
                .AsEnumerable();
        }

        public Product GetProductById(int id)
        {
            return DbContext.Products.SingleOrDefault(m => m.Id == id);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            await DbContext.Products.AddAsync(product);

            await DbContext.SaveChangesAsync();

            return product;
        }
    }
}