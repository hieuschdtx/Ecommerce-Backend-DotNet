using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.UserService;

public interface IUserService
{
    Task<bool> ExistsEmailAsync(string email);
    Task<bool> ExistsPhoneNumberAsync(string phoneNumber);
    Task<bool> MacthRefreshToken(string refreshToken);
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<bool> MatchVerifyCodeUserAsync(string email, string vefiryCode, decimal expTime);
}