using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        public ProductMediaFileType FileType { get; set; }

        [NotMapped]
        public byte[] MediaContent { get; set; }

        [NotMapped]
        public Uri Path => GetFilePath();

        
        private Uri GetFilePath()
        {
            var uri = string.Empty;

            uri += "~/";

            uri += MediaType == ProductMediaType.Image ? "Images/" : "Video/";

            uri += ProductId + Id + ".";

            uri += FileType.ToString();

            return new Uri(uri, UriKind.Relative);
        } 
    }
}