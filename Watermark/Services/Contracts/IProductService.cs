using System.Collections.Generic;
using System.Threading.Tasks;
using Watermark.Models.Products;

namespace Watermark.Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int id);

        Task<Product> AddProductAsync(Product product);
    }
}