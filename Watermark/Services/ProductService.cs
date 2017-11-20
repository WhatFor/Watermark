using System.Collections.Generic;
using System.Threading.Tasks;
using Watermark.Models.Products.Contracts;
using Watermark.Services.Contracts;

namespace Watermark.Services
{
    public class ProductService : IProductService
    {

        public ProductService()
        {
        }

        public Task<List<IProduct>> GetAllProducts()
        {
            return null;
        }

        public async Task<IProduct> CreateProduct(IProduct product)
        {
            return null;
        }
    }
}