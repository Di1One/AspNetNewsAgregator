using AspNetNewsAgregator.Core.DataTransferObjects;

namespace AspNetNewsAgregator.Core.Abstractions;

public interface IUserService
{
    Task<bool> IsUserExists(Guid userId);
    Task<bool> IsUserExists(string email);
    Task<IEnumerable<UserDto>> GetAllUsers();
    Task<bool> CheckUserPassword(string email, string password);
    Task<bool> CheckUserPassword(Guid userId, string password);
    Task<int> RegisterUser(UserDto dto, string password);
    Task<UserDto?> GetUserByEmailAsync(string email);
}