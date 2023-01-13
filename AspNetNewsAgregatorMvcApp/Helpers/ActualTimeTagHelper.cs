using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetNewsAgregatorMvcApp.Helpers
{
    public class ActualTimeTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "div";
            output.Content.SetContent($"Actual server date: {DateTime.Now:R}"); 
        }
    }
}
