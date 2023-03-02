using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.WebAPI.Models.Responces;

namespace AspNetNewsAgregator.WebAPI.Utils
{
    public interface IJwtUtil
    {
        Task<TokenResponse> GenerateTokenAsync(UserDto dto);
        Task RemoveRefreshTokenAsync(Guid requestRefreshToken);
    }
}