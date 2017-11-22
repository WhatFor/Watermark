using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Products
{
    public class ProductSKU
    {
        [Key]
        public int Id { get; set; }

        public string SKU { get; set; }
    }
}