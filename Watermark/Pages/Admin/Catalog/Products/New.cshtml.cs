using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Watermark.Models;
using Watermark.Models.Products;
using Watermark.Services.Contracts;

namespace Watermark.Pages.Admin.Catalog.Products
{
    public class NewModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public Currency GlobalCurrency { get; set; }

        private readonly IConfigurationService configurationService;

        public NewModel(IConfigurationService configurationService)
        {
            this.configurationService = configurationService;

            GlobalCurrency = configurationService.GetGlobalCurrency();
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
