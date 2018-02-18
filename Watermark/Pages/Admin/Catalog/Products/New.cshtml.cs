using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Watermark.Models.Products;
using Watermark.Services.Contracts;

namespace Watermark.Pages.Admin.Catalog.Products
{
    public class NewModel : WatermarkPageModel
    {
        [BindProperty]
        public Product Product { get; set; }

        private readonly IProductService productService;

        public NewModel(IConfigurationService config, IProductService productService) : base(config)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> OnGetAsync()
        {
            if (Product == null)
            {
                Product = new Product();
            }

            return Page();
        }

        [HttpPost]
        public async Task<ContentResult> OnPostCreateAsync()
        {
            var product = await productService.AddProductAsync(Product);

            return Content(product.Id.ToString());
        }
    }
}
