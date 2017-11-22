using System.Collections.Generic;
using System.Linq;
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
            return DbContext.Products.AsEnumerable();
        }

        public Product GetProductById(int id)
        {
            return DbContext.Products.SingleOrDefault(m => m.Id == id);
        }
    }
}