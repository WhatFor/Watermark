using System.Text.RegularExpressions;

namespace Watermark.Models.Products
{
    public class ProductName
    {
        public string DisplayName { get; set; }

        public string SafeName  => GetSafeName();

        private string GetSafeName()
        {
            var alphaNumericExp = new Regex("[^a-zA-Z0-9 -]");

            return alphaNumericExp.Replace(DisplayName, string.Empty);
        }
    }
}