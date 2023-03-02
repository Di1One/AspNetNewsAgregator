using AspNetNewsAgregator.Core.DataTransferObjects;
using MediatR;

namespace AspNetNewsAgregator.Data.CQS.Queries
{
    public class GetUserByRefreshTokenQuery : IRequest<UserDto>
    {
        public Guid RefreshToken { get; set; }
    }
}
