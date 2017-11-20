namespace Watermark.Models
{
    public class PriceDetail
    {
        public decimal Cost { get; set; }

        public TaxRate TaxRate { get; set; }

        public bool IncludesTax { get; set; }
    }
}