using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Watermark.Models;
using Watermark.Services.Contracts;

namespace Watermark.Controllers.Admin
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;

        private readonly IApplicationUserService _userService;

        public AccountController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            ILogger<AccountController> logger,
            IApplicationUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;

            _userService = userService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToPage("/Admin/Account/SignedOut");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task SetUserFirstLoginTutorialComplete()
        {
            var userId = _userManager.GetUserId(User);

            await _userService.SetUserFirstLoginTutorialComplete(userId);
        }
    }
}
