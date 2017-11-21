using System.Collections.Generic;
using Watermark.Models.Products;

namespace Watermark.Repository.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int id);
    }
}