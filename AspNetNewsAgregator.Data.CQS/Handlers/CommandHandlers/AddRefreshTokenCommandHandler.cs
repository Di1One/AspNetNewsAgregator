using AspNetNewsAgregator.Data.CQS.Commands;
using AspNetNewsAgregator.DataBase;
using AspNetNewsAgregator.DataBase.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetNewsAgregator.Data.CQS.Handlers.CommandHandlers
{
    public class AddRefreshTokenCommandHandler : IRequestHandler<AddRefreshTokenCommand, Unit>
    {
        private readonly GoodNewsAggregatorContext _context;
        private readonly IMapper _mapper;

        public AddRefreshTokenCommandHandler(GoodNewsAggregatorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddRefreshTokenCommand command, CancellationToken token)
        {
            var rt = new RefreshToken()
            {
                Id = Guid.NewGuid(),
                Token = command.TokenValue,
                UserId = command.UserId,
            };

            await _context.RerfreshTokens.AddAsync(rt, token);
            await _context.SaveChangesAsync(token);
            return Unit.Value;
        }
    }
}
