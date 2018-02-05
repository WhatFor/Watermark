using Microsoft.AspNetCore.Mvc;
using Watermark.Models.Products;
using Watermark.Services.Contracts;

namespace Watermark.Pages.Admin.Catalog.Products
{
    public class NewModel : WatermarkPageModel
    {
        [BindProperty]
        public Product Product { get; set; }

        public NewModel(IConfigurationService config) : base(config)
        {

        }

        public void OnGet()
        {
            if (Product == null)
            {
                Product = new Product();
            }
        }
    }
}
