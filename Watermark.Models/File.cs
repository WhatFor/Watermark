using System;
using System.ComponentModel.DataAnnotations;
using Watermark.Models.Contracts;

namespace Watermark.Models
{
    public class File : IFile
    {
        /// <summary>
        /// Type of file. E.g. MP4.
        /// </summary>
        [Required]
        public FileType FileType { get; set; }

        /// <summary>
        ///  Determined by the File Type. Either Image or Video.
        /// </summary>
        [Required]
        public MediaType MediaType => DetermineMediaType();

        /// <summary>
        /// The file contents.
        /// </summary>
        public string Base64Contents { get; set; }

        /// <summary>
        /// The path to the file.
        /// </summary>
        public Uri Path { get; set; }

        /// <summary>
        /// Checks if the file is of a media type.
        /// </summary>
        public bool IsMedia => DetermineIsMedia();

        /// <summary>
        /// Uses the file-extension, provided by the form-post, to determine if the media is an Image or Video.
        /// </summary>
        /// <returns>ProductMediaType</returns>
        private MediaType DetermineMediaType()
        {
            if (!IsMedia)
            {
                return MediaType.Unknown;
            }

            switch (FileType)
            {
                // Unable to determine
                case FileType.Unknown:
                    return MediaType.Unknown;

                // Images
                case FileType.JPEG:
                    return MediaType.Image;

                case FileType.JPG:
                    return MediaType.Image;

                case FileType.PNG:
                    return MediaType.Image;

                // Video
                case FileType.MP4:
                    return MediaType.Video;

                default:
                    return MediaType.Unknown;
            }
        }

        private bool DetermineIsMedia()
        {
            return (FileType == FileType.JPEG ||
                    FileType == FileType.JPG ||
                    FileType == FileType.PNG ||
                    FileType == FileType.MP4);
        }
    }
}
