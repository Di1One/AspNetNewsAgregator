using AspNetNewsAgregator.Core.DataTransferObjects;
using MediatR;

namespace AspNetNewsAgregator.Data.CQS.Commands
{
    public class AddArticleDataFromRssFeedCommand : IRequest<Unit> 
    {
        public IEnumerable<ArticleDto>? Articles;
    }
}
