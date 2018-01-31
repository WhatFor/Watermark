using System.ComponentModel.DataAnnotations;

namespace Watermark.Models
{
    public class PriceDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Base Price", Description = "A product's base price, applied before any promotions or tax.")]
        public virtual decimal Cost { get; set; }

        public TaxRate TaxRate { get; set; }

        public bool IncludesTax { get; set; }
    }
}