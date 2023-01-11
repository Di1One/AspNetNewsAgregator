namespace AspNetNewsAgregator.DataBase.Entities
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDiscription { get; set; }
        public string Text { get; set; }
        public DateTime PublicationDate { get; set; }

        public Guid SourceId { get; set; }
        public Source Source { get; set; }  

        public List<Comment> Comments { get; set; }  

    }
}