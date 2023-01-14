using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetNewsAgregatorMvcApp.Helpers
{
    public class ServerDataTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "div";
            var processId = Thread.GetCurrentProcessorId();
            output.Content.SetContent($"Your app processor id: {processId}");
        }
    }
}
