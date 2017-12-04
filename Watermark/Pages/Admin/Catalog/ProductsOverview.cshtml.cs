using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Watermark.Models.Products;
using Watermark.Services.Contracts;

namespace Watermark.Pages.Admin.Catalog
{
    public class ProductsOverviewModel : PageModel
    {
        private IProductService ProductService;

        public ProductsOverviewModel(IProductService productService)
        {
            ProductService = productService;
        }

        [BindProperty]
        public IEnumerable<Product> Products { get; set; }

        public IActionResult OnGet()
        {
            Products = ProductService.GetAllProducts();

            return Page();
        }
    }
}