using System.ComponentModel.DataAnnotations;

namespace Watermark.Models
{
    public enum Currency
    {
        [Display(Name = "None")]
        NIL,

        [Display(Name = "Great British Pound")]
        [Country("UK")]
        GBP,

        [Display(Name = "US Dollar")]
        [Country("US")]
        USD,
    }
}