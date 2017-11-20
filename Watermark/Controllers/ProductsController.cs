using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Watermark.Models.Products.Contracts;
using Watermark.Services.Contracts;

namespace Watermark.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService ProductService;

        public ProductsController(IProductService productService)
        {
            ProductService = productService;
        }

        [HttpGet]
        public async Task<JsonResult> GetAllProducts()
        {
            var result = await ProductService.GetAllProducts();
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<JsonResult> CreateProduct([FromBody]IProduct product)
        {
            var result = await ProductService.CreateProduct(product);
            return new JsonResult(result);
        }
    }
}