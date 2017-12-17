using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Products
{
    public enum ProductType
    {
        [Display(Name = "Physical")]
        PhysicalProduct = 1,

        [Display(Name = "Digital")]
        DigitalProduct = 2,
    }
}