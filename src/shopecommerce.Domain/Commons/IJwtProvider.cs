using shopecommerce.Domain.Entities;

namespace shopecommerce.Domain.Commons;

public interface IJwtProvider
{
    Task<string> GenerateAccessTokenAsync(Users user);
    void SaveCookiesStorage(string token);
    string GenerateRefreshToken();
    Task SignOutAsync();
    Task<bool> VerifyAccessTokenAsync(string token);
}