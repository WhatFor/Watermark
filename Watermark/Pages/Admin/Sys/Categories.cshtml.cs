using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watermark.Models.Products;
using Watermark.Services.Contracts;

namespace Watermark.Pages.Admin.Sys
{
    public class CategoriesModel : PageModel
    {
        private readonly ICategoriesService categoriesService;

        [BindProperty]
        public List<ProductCategory> Categories { get; set; }

        public CategoriesModel(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await categoriesService.GetProductCategoriesAsync();

            return Page();
        }
    }
}