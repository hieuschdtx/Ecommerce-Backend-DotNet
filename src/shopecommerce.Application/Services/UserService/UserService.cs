using Dapper;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.UserService;

public class UserService : UserServiceBase, IUserService
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
        const string commnandText = @"select exists(select 1 from users where phone_number = @phoneNumber)";
        using var conn = _factory.GetOpenConnection();

        return await conn.ExecuteScalarAsync<bool>(commnandText, new { phoneNumber });
    }

    public async Task<bool> MacthRefreshToken(string refreshToken)
    {
        const string commnandText = @"select exists(select 1 from users where refresh_token = @refreshToken)";
        using var conn = _factory.GetOpenConnection();

        return await conn.ExecuteScalarAsync<bool>(commnandText, new { refreshToken });
    }

    public async Task<bool> MatchVerifyCodeUserAsync(string email, string vefiryCode, decimal expTime)
    {
        const string commnandText = @"select exists(select 1 from users where email = @email and verify_code = @vefiryCode and verify_time_exp > @expTime)";
        using var conn = _factory.GetOpenConnection();

        return await conn.ExecuteScalarAsync<bool>(commnandText, new { email, vefiryCode, expTime });
    }
}