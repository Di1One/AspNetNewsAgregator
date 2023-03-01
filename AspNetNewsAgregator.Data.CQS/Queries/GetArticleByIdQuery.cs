using AspNetNewsAgregator.Core.DataTransferObjects;
using MediatR;

namespace AspNetNewsAgregator.Data.CQS.Queries
{
    public class GetArticleByIdQuery : IRequest<ArticleDto>
    {
        public Guid Id { get; set; }
    }
}
