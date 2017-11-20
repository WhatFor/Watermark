namespace Watermark.Models.Products
{
    public class ProductMedia
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public ProductMediaType MediaType { get; set; }

        public bool PrimaryMedia { get; set; }
    }
}