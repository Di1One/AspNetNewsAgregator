using AspNetNewsAgregator.Core.DataTransferObjects;
using MediatR;

namespace AspNetNewsAgregator.Data.CQS.Commands
{
    public class AddRefreshTokenCommand : IRequest<Unit> 
    {
        public Guid TokenValue;
        public Guid UserId;
    }
}
