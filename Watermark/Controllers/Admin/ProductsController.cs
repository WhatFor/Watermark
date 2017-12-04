using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Watermark.Models.Products;

namespace Watermark.Controllers.Admin
{
    public class ProductsController : Controller
    {
        public async Task<string> AddProductAsync(Product product)
        {
            return $"Waddup, It's Me, ya boi. Looks like your product name is: {product.ProductName.DisplayName}";
        }
    }
}