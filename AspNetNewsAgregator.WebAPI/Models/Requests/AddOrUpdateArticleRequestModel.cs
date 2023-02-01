namespace AspNetNewsAgregator.WebAPI.Models.Requests;

public class AddOrUpdateArticleRequestModel
{
    public string Title { get; set; }
    public string Category { get; set; }
    public string ShortSummary { get; set; }
    public string Text { get; set; }
}