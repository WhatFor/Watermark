using System.ComponentModel.DataAnnotations;
using Watermark.Models.Products.Contracts;

namespace Watermark.Models.Products
{
    public class ProductConfiguration
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ConfigurationType Type { get; set; }

        public bool Active { get; set; } = false;

        public ProductConfiguration Activate()
        {
            Active = true;
            return this;
        }

        public ProductConfiguration Deactivate()
        {
            Active = false;
            return this;
        }
    }
}