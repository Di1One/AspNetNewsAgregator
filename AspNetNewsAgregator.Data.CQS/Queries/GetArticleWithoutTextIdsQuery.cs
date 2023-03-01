using AspNetNewsAgregator.Core.DataTransferObjects;
using MediatR;

namespace AspNetNewsAgregator.Data.CQS.Queries
{
    public class GetArticleWithoutTextIdsQuery : IRequest<Guid[]>
    {

    }
}
