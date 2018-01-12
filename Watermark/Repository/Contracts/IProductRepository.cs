using System.Collections.Generic;
using System.Threading.Tasks;
using Watermark.Models.Products;

namespace Watermark.Repository.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int id);

        Task<Product> AddProductAsync(Product product);
    }
}