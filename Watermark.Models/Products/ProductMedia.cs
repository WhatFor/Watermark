using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Products
{
    public class ProductMedia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Display(Name = "Description", Description = "A short description of the image, displayed on the product page.")]
        public string MediaDescription { get; set; }

        [Required]
        public ProductMediaType MediaType { get; set; }

        [Required]
        [Display(Name = "Primary Media", Description = "Wether this is the first image for the product.")]
        public bool PrimaryMedia { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Order { get; set; }

        [Required]
        [Display(Name = "Hide", Description = "Wether to hide this image from the product page.")]
        public bool Hide { get; set; }
    }
}