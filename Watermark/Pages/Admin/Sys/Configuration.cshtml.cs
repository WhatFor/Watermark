using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Watermark.Models.Admin.Configuration;
using Watermark.Services.Contracts;

namespace Watermark.Pages.Admin.Sys
{
    public class ConfigurationModel : PageModel
    {
        [BindProperty]
        public Configuration Config { get; set; }

        private readonly IConfigurationService configService;

        public ConfigurationModel(IConfigurationService configService)
        {
            this.configService = configService;
        }

        public IActionResult OnGet()
        {
            Config = configService.GetSiteConfiguration();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Configuration config)
        {
            var result = await configService.UpdateConfigurationAsync(config);

            return Page();
        }
    }
}