using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.Data.CQS.Queries;
using AspNetNewsAgregator.DataBase;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetNewsAgregator.Data.CQS.Handlers.QueryHandlers
{
    public class GetUserByRefreshTokenQueryHandler : IRequestHandler<GetUserByRefreshTokenQuery, UserDto>
    {
        private readonly GoodNewsAggregatorContext _context;
        private readonly IMapper _mapper;

        public GetUserByRefreshTokenQueryHandler(GoodNewsAggregatorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var user = (await _context.RerfreshTokens
                .Include(token => token.User)
                .ThenInclude(user => user.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync(token => token.Token.Equals(request.RefreshToken), cancellationToken))?.User;

            return _mapper.Map<UserDto>(user);
        }
    }
}
