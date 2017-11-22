using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Products
{
    public class ProductPricing
    {
        [Key]
        public int Id { get; set; }

        public PriceDetail BasePrice { get; set; }

        public PriceDetail SpecialPrice { get; set; }

        // TODO - Multi-buy pricing
    }
}