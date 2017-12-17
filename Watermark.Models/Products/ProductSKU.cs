using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Products
{
    public class ProductSKU
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product SKU", Description = "The unique Stock-Keeping Unit for this product.")]
        public string SKU { get; set; }
    }
}