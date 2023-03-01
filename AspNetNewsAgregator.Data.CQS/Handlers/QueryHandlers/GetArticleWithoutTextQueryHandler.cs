using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.Data.CQS.Queries;
using AspNetNewsAgregator.DataBase;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetNewsAgregator.Data.CQS.Handlers.QueryHandlers
{
    public class GetArticleWithoutTextQueryHandler : IRequestHandler<GetArticleWithoutTextIdsQuery, Guid[]>
    {
        private readonly GoodNewsAggregatorContext _context;
        private readonly IMapper _mapper;

        public GetArticleWithoutTextQueryHandler(GoodNewsAggregatorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid[]> Handle(GetArticleWithoutTextIdsQuery request, CancellationToken cancellationToken)
        {
            var articlesWithEmptyTextIds = await _context.Articles
                .AsNoTracking()
                .Where(article => string.IsNullOrEmpty(article.Text))
                .Select(article => article.Id)
                .ToArrayAsync(cancellationToken);

            return articlesWithEmptyTextIds;
        }
    }
}
