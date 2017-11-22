using System.ComponentModel.DataAnnotations;

namespace Watermark.Models
{
    public class PriceDetail
    {
        [Key]
        public int Id { get; set; }

        public decimal Cost { get; set; }

        public TaxRate TaxRate { get; set; }

        public bool IncludesTax { get; set; }
    }
}