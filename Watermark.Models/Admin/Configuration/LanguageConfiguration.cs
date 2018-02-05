using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Admin.Configuration
{
    public class LanguageConfiguration
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Default Language", Description = "The default language setting for the admin panel and the site.")]
        public Language DefaultLanguage { get; set; }
    }
}