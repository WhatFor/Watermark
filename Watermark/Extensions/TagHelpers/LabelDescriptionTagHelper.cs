using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Watermark.Extensions.TagHelpers
{
    [HtmlTargetElement("label", Attributes = _tagAttribute)]
    public class LabelDescriptionTagHelper : LabelTagHelper
    {
        private const string _tagAttribute = "hover-desc";

        [HtmlAttributeName(_tagAttribute)]
        public ModelExpression Description { get; set; }

        public LabelDescriptionTagHelper(IHtmlGenerator generator) : base(generator)
        {

        }

        public override int Order => int.MaxValue;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);

            if (!string.IsNullOrWhiteSpace(Description.Metadata.Description))
            {
                output.Content.Append($"<p>{Description.Metadata.Description}</p>");
            }
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (!string.IsNullOrWhiteSpace(Description.Metadata.Description))
            {
                output.Content.Append($"<p>{Description.Metadata.Description}</p>");
            }
        }
    }
}