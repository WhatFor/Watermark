using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Admin.Configuration
{
    /// <summary>
    /// Global configuration for both the admin panel and the e-commerce site.
    /// </summary>
    public class Configuration
    {
        [Key]
        public int Id { get; set; }

        public CurrencyConfiguration CurrencyConfiguration { get; set; }
    }
}