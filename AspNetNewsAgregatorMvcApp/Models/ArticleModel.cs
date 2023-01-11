namespace AspNetNewsAgregatorMvcApp.Models
{
    public class ArticleModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string ShortSummary { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
