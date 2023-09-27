using shopecommerce.Domain.Entities;

namespace shopecommerce.Domain.Commons;

public interface IJwtProvider
{
    Task<string> GenerateAsync(Users user);
    void SaveCookiesStorage(string token);
    Task SignOutAsync();
}