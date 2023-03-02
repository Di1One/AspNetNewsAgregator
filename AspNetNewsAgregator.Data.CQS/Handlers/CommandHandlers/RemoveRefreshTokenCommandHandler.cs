using AspNetNewsAgregator.Data.CQS.Commands;
using AspNetNewsAgregator.DataBase;
using AspNetNewsAgregator.DataBase.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetNewsAgregator.Data.CQS.Handlers.CommandHandlers
{
    public class RemoveRefreshTokenCommandHandler : IRequestHandler<RemoveRefreshTokenCommand, Unit>
    {
        private readonly GoodNewsAggregatorContext _context;
        private readonly IMapper _mapper;

        public RemoveRefreshTokenCommandHandler(GoodNewsAggregatorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RemoveRefreshTokenCommand command, CancellationToken token)
        {
            var refreshToken = await _context.RerfreshTokens
                .FirstOrDefaultAsync(rt => command.TokenValue.Equals(rt.Token), token);

            _context.RerfreshTokens.Remove(refreshToken);
            await _context.SaveChangesAsync(token);
            return Unit.Value;
        }
    }
}
