using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Products
{
    public class ProductDescription
    {
        [Key]
        public int Id { get; set; }

        public Language Language { get; set; }

        public string Body { get; set; }
    }
}