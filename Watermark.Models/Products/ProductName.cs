using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Watermark.Models.Products
{
    public class ProductName
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name", Description = "The display name for this product, as shown to customers.")]
        public string DisplayName { get; set; }

        [NotMapped]
        public string SafeName  => GetSafeName();

        private string GetSafeName()
        {
            var alphaNumericExp = new Regex("[^a-zA-Z0-9 -]");

            return alphaNumericExp.Replace(DisplayName, string.Empty);
        }
    }
}