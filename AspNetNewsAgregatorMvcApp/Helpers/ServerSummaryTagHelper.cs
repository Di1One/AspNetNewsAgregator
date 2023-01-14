using System.Text;
using AspNetNewsAgregator.Core.Abstractions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetNewsAgregatorMvcApp.Helpers;

public class ServerSummaryTagHelper : TagHelper
{
    private readonly ISourceService _sourceService; 
    public bool Visible { get; set; }
    public StyleInformation? Style { get; set; }

    public ServerSummaryTagHelper(ISourceService sourceService)
    {
        _sourceService = sourceService;
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "div";

        var target = await output.GetChildContentAsync();

        var sb = new StringBuilder("<h3>Server information:</h3>");
        sb.Append(target.GetContent());

        var style = "";

        if (Visible)
        {
            var randomSourceName = (await _sourceService.GetSourcesAsync())
                .FirstOrDefault()?
                .Name;
            sb.Append($"<h6> Random source name: {randomSourceName}</h6>");
        }

        if (Style != null)
        {
            if (Style.Color != null)
            {
                style = $"color: {Style.Color};";
            }

            if (Style.FontSize != null)
            {
                style = $"{style}font-size: {Style.FontSize};";
            }
        }

        output.Attributes.SetAttribute("style", style);
        output.Content.SetHtmlContent(sb.ToString());
    }
}

public class StyleInformation
{
    public string? Color { get; set; }
    public int? FontSize { get; set; }
}
