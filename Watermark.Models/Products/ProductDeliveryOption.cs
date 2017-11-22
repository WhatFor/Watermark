using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Products
{
    public class ProductDeliveryOption
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}