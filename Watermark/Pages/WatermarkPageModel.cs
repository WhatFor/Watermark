using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Watermark.Models;
using Watermark.Services.Contracts;

namespace Watermark.Pages
{
    public class WatermarkPageModel : PageModel
    {
        [BindProperty]
        public Currency? GlobalCurrency { get; set; }

        [BindProperty]
        public Language? DefaultLanguage { get; set; }

        private readonly IConfigurationService configurationService;

        public WatermarkPageModel(IConfigurationService configurationService)
        {
            this.configurationService = configurationService;

            GlobalCurrency = configurationService.GetGlobalCurrency();
            DefaultLanguage = configurationService.GetDefaultLanguage();
        }
    }
}