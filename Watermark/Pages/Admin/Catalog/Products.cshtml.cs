using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Watermark.Pages.Admin.Catalog
{
    public class ProductsModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}