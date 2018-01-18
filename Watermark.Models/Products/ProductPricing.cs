using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Products
{
    public class ProductPricing
    {
        [Key]
        public int Id { get; set; }

        public PriceDetail BasePrice { get; set; }

        public SpecialPriceDetail SpecialPrice { get; set; }

        [Display(Name = "RRP", Description = "The manufacturer's recommended retail price.")]
        public decimal ManufacturerRRP { get; set; }

        [Display(Name = "Display RRP", Description = "Wether the RRP should be displayed on the product page.")]
        public bool DisplayManufacturerRRP { get; set; }

        public decimal GetPrice()
        {
            if (SpecialPrice != null && SpecialPrice.IsSpecialActive)
            {
                return SpecialPrice.Cost;
            }
            else
            {
                return BasePrice.Cost;
            }
        }

        // TODO - Multi-buy pricing
    }
}