using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Watermark.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        public DashboardModel()
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}