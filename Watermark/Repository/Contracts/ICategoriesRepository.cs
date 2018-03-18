using System.Collections.Generic;
using System.Threading.Tasks;
using Watermark.Models.Products;

namespace Watermark.Repository.Contracts
{
    public interface ICategoriesRepository
    {
        Task<ProductCategory> GetProductCategoryByIdAsync(int id);

        Task<ProductCategory> GetProductCategoryByNameAsync(string name);

        Task<List<ProductCategory>> GetProductCategoriesAsync();
    }
}