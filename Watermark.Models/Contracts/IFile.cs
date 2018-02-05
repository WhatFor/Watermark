using System;
using Watermark.Models.Products;

namespace Watermark.Models.Contracts
{
    public interface IFile
    {
        FileType FileType { get; set; }

        string Base64Contents { get; set; }

        Uri Path { get; set; }

        MediaType MediaType { get; }

        bool IsMedia { get; }
    }
}