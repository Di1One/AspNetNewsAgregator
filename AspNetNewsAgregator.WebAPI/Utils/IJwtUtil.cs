using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.WebAPI.Models.Responces;

namespace AspNetNewsAgregator.WebAPI.Utils
{
    public interface IJwtUtil
    {
        TokenResponse GenerateToken(UserDto dto);
    }
}