using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Watermark.Models.Products
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public List<ProductCategory> Children { get; set; }
    }
}