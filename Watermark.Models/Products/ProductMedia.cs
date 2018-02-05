using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Watermark.Models.Products
{
    public class ProductMedia : File
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        /// <summary>
        /// The image description, displayed on the product page.
        /// </summary>
        [Display(Name = "Description", Description = "A short description of the image, displayed on the product page.")]
        public string MediaDescription { get; set; }

        /// <summary>
        /// Wether the media element is the primary media for the product. Will be used as the product's image in product listings and thumbnails.
        /// </summary>
        [Required]
        [Display(Name = "Primary Media", Description = "Wether this is the first image for the product, displayed in listings and thumbnails.")]
        public bool PrimaryMedia => CalculatePrimary();

        /// <summary>
        /// The order in which to display the media on the product page.
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public int Order { get; set; }

        /// <summary>
        /// Toggles wether the media is displayed on the product page.
        /// </summary>
        [Required]
        [Display(Name = "Hide", Description = "Wether to hide this image from the product page.")]
        public bool Hide { get; set; }

        /// <summary>
        /// Base 64 Encoded file data.
        /// </summary>
        [NotMapped]
        public string Content { get; set; }

        /// <summary>
        /// The auto-generated, relative file-path of the media.
        /// </summary>
        [NotMapped]
        public new Uri Path => GetFilePath();

        /// <summary>
        /// Using various elements of the product media, we will craft a filepath to point to the storage location
        /// of our image.
        /// </summary>
        /// <returns>A URI pointing to the storage location of the media.</returns>
        private Uri GetFilePath()
        {
            var uri = string.Empty;

            uri += "~/";

            uri += MediaType == MediaType.Image ? "Images/" : "Video/";

            uri += Content.GetHashCode() + ".";

            uri += FileType.ToString();

            return new Uri(uri, UriKind.Relative);
        }



        /// <summary>
        /// If the media element is first in the Order, we treat it as the 'Primary Media'.
        /// </summary>
        /// <returns>Wether the media is first - i.e. the primary media.</returns>
        private bool CalculatePrimary()
        {
            return Order == 0;
        }
    }
}