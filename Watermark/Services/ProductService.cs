using System.Collections.Generic;
using System.Threading.Tasks;
using Watermark.Models.Products;
using Watermark.Services.Contracts;

namespace Watermark.Services
{
    public class ProductService : IProductService
    {

        public ProductService()
        {
        }

        public Task<List<Product>> GetAllProducts()
        {
            return null;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            return null;
        }
    }
}