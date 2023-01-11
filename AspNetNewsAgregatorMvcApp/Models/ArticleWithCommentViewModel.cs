using AspNetNewsAgregator.Core.DataTransferObjects;

namespace AspNetNewsAgregatorMvcApp.Models
{
    public class ArticleWithCommentViewModel
    {
        public ArticleDto Article { get; set; }
        public List<string> Comments { get; set; }
    }
}
