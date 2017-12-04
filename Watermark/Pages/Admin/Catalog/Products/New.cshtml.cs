using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Watermark.Models.Products;

namespace Watermark.Pages.Admin.Catalog.Products
{
    public class NewModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }

        public void OnGet()
        {

        }
    }
}
