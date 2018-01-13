using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Admin.Configuration
{
    public class CurrencyConfiguration
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Global Currency", Description = "The default currency setting for all monetary values.")]
        public Currency GlobalCurrency { get; set; }
    }
}