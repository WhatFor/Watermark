using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Watermark.Models.Products;

namespace Watermark.Extensions
{
    public static class ProductTypeExtensions
    {
        public static string ToDisplayName(this ProductType value)
        {
            return value.GetType()
                            .GetMember(value.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}