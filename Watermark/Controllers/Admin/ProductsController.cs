using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Watermark.Models.Products;
using Watermark.Services.Contracts;

namespace Watermark.Controllers.Admin
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            product = await productService.AddProductAsync(product);

            return product.Id;
        }
    }
}