using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Products
{
    public class ProductMedia
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public ProductMediaType MediaType { get; set; }

        public bool PrimaryMedia { get; set; }
    }
}