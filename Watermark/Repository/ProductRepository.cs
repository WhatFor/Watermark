using System.Collections.Generic;
using Watermark.Models.Products;
using Watermark.Repository.Contracts;

namespace Watermark.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(string connectionString) : base (connectionString)
        {

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return Query<Product>("SELECT * FROM Products");
        }

        public Product GetProductById(int id)
        {
            return QueryFirstOrDefault<Product>("SELECT * FROM Products WHERE Id = @id", new { id });
        }
    }
}