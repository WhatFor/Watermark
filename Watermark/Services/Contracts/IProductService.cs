using System.Collections.Generic;
using System.Threading.Tasks;
using Watermark.Models.Products;

namespace Watermark.Services.Contracts
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();

        Task<Product> CreateProduct(Product product);
    }
}