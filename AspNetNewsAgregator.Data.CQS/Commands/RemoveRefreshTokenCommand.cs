using AspNetNewsAgregator.Core.DataTransferObjects;
using MediatR;

namespace AspNetNewsAgregator.Data.CQS.Commands
{
    public class RemoveRefreshTokenCommand : IRequest<Unit> 
    {
        public Guid TokenValue;
    }
}
