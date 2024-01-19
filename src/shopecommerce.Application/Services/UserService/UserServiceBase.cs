using Dapper;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.UserService;

public class UserServiceBase
{
    protected readonly ISqlConnectionFactory _factory;

    public UserServiceBase(ISqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        const string queryString = @"select * from users";
        using var conn = _factory.GetOpenConnection();
        return await conn.QueryAsync<UserDto>(queryString);
    }
    public async Task<UserDto> GetByIdAsync(string id)
    {
        const string queryString = @"select * from users where id = @id";
        using var conn = _factory.GetOpenConnection();
        return await conn.QuerySingleOrDefaultAsync<UserDto>(queryString, new { id });
    }
}