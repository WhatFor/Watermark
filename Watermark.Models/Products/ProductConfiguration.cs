using Watermark.Models.Products.Contracts;

namespace Watermark.Models.Products
{
    public class ProductConfiguration
    {
        public string Name { get; set; }

        public IConfigurationType Type { get; set; }

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