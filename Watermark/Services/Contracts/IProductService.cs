using System.Collections.Generic;
using System.Threading.Tasks;
using Watermark.Models.Products.Contracts;

namespace Watermark.Services.Contracts
{
    public interface IProductService
    {
        Task<List<IProduct>> GetAllProducts();

        Task<IProduct> CreateProduct(IProduct product);
    }
}