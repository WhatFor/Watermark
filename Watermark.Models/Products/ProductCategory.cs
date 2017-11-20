using System.Collections.Generic;

namespace Watermark.Models.Products
{
    public class ProductCategory
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public List<ProductCategory> Children { get; set; }
    }
}