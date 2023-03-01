using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.Data.CQS.Queries;
using AspNetNewsAgregator.DataBase;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetNewsAgregator.Data.CQS.Handlers.QueryHandlers
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, ArticleDto?>
    {
        private readonly GoodNewsAggregatorContext _context;
        private readonly IMapper _mapper;

        public GetArticleByIdQueryHandler(GoodNewsAggregatorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ArticleDto> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await _context.Articles
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id.Equals(request.Id), cancellationToken);

            return _mapper.Map<ArticleDto>(article);
        }
    }
}
