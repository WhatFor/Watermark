using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Watermark.Models.Admin;
using Watermark.Models.Products;
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
        [ServiceFilter(typeof(AdminAuthorizationAttribute))]
        public async Task<JsonResult> CreateProduct([FromBody]Product product)
        {
            var result = await ProductService.CreateProduct(product);
            return new JsonResult(result);
        }
    }
}