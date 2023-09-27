using Dapper;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.UserService;

public class UserService : UserServiceBase,IUserService
{
    public UserService(ISqlConnectionFactory factory) : base(factory)
    {
    }
    
    public async Task<bool> ExistsEmailAsync(string email)
    {
        const string commnandText = @"select exists(select 1 from users where email = @email)";
        using var conn = _factory.GetOpenConnection();

        return await conn.ExecuteScalarAsync<bool>(commnandText, new { email });
    }

    public async Task<bool> ExistsPhoneNumberAsync(string phoneNumber)
    {
        const string commnandText = @"select exists(select 1 from users where email = @phoneNumber)";
        using var conn = _factory.GetOpenConnection();

        return await conn.ExecuteScalarAsync<bool>(commnandText, new { phoneNumber });
    }
}