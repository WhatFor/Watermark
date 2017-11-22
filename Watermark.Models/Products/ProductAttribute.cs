using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Products
{
    public class ProductAttribute
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}