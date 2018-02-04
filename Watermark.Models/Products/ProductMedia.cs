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

        /// <summary>
        /// The image description, displayed on the product page.
        /// </summary>
        [Display(Name = "Description", Description = "A short description of the image, displayed on the product page.")]
        public string MediaDescription { get; set; }

        /// <summary>
        ///  Determined by the File Type. Either Image or Video.
        /// </summary>
        [Required]
        public ProductMediaType MediaType => DetermindMediaType();

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
        /// The file-type of the media, e.g. PNG. Provided by the form-post data.
        /// </summary>
        [Required]
        public ProductMediaFileType FileType { get; set; }

        /// <summary>
        /// Base 64 Encoded file data.
        /// </summary>
        [NotMapped]
        public string MediaContent { get; set; }

        /// <summary>
        /// The auto-generated, relative file-path of the media.
        /// </summary>
        [NotMapped]
        public Uri Path => GetFilePath();

        /// <summary>
        /// Using various elements of the product media, we will craft a filepath to point to the storage location
        /// of our image.
        /// </summary>
        /// <returns>A URI pointing to the storage location of the media.</returns>
        private Uri GetFilePath()
        {
            var uri = string.Empty;

            uri += "~/";

            uri += MediaType == ProductMediaType.Image ? "Images/" : "Video/";

            uri += ProductId + Id + ".";

            uri += FileType.ToString();

            return new Uri(uri, UriKind.Relative);
        }

        /// <summary>
        /// Uses the file-extension, provided by the form-post, to determine if the media is an Image or Video.
        /// </summary>
        /// <returns>ProductMediaType</returns>
        private ProductMediaType DetermindMediaType()
        {
            switch (FileType)
            {
                // Unable to determine
                case ProductMediaFileType.Unknown:
                    return ProductMediaType.Unknown;

                // Images
                case ProductMediaFileType.JPEG:
                    return ProductMediaType.Image;

                case ProductMediaFileType.JPG:
                    return ProductMediaType.Image;

                case ProductMediaFileType.PNG:
                    return ProductMediaType.Image;

                // Video
                case ProductMediaFileType.MP4:
                    return ProductMediaType.Video;

                default:
                    return ProductMediaType.Unknown;
            }
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