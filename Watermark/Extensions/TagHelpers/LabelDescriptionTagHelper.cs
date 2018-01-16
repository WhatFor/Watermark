using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
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
                var id = $"hover-desc-{Guid.NewGuid()}";

                output.Attributes.Add("Id", id);
                output.AddClass("hover-desc-label");

                output.Content.AppendHtml($"<div class=\"hover-desc-popup\" data-for=\"{id}\">{Description.Metadata.Description}</div>");
            }
        }
    }
}