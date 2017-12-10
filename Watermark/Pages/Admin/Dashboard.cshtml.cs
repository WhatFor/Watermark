using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Watermark.Models;
using Watermark.Services.Contracts;

namespace Watermark.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly IApplicationUserService UserService;

        public DashboardModel(UserManager<ApplicationUser> userManager, IApplicationUserService userService)
        {
            UserManager = userManager;
            UserService = userService;
        }

        public bool IsFirstLogin { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await UserManager.GetUserAsync(HttpContext.User);
            IsFirstLogin = user.IsFirstLogin;

            return Page();
        }
    }
}