using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Products
{
    public class ProductSettingOverride
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Setting { get; set; }

        public string Value { get; set; }
    }
}