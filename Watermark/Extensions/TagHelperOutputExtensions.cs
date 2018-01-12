using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;

namespace Watermark.Extensions
{
    public static class TagHelperOutputExtensions
    {
        /// <summary>
        /// A method to either create the class attribute and assign a class to an HTML element, or to append a new class to the existing attribute if needed.
        /// </summary>
        /// <param name="output">The TagHelperOutput class to add the class to.</param>
        /// <returns>The input TagHelperOutput class will be returned with the added class.</returns>
        public static TagHelperOutput AddClass(this TagHelperOutput output, string newClass)
        {
            var existingClass = output.Attributes.FirstOrDefault(f => f.Name == "class");
            var cssClass = string.Empty;

            if (existingClass != null)
            {
                cssClass = existingClass.Value.ToString();
            }

            cssClass = $"{cssClass} {newClass}";

            var ta = new TagHelperAttribute("class", cssClass);
            output.Attributes.Remove(existingClass);
            output.Attributes.Add(ta);

            return output;
        }
    }
}