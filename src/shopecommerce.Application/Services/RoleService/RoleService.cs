using Dapper;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.RoleService
{
    public class RoleService : RoleServiceBase,IRoleService
    {
        public RoleService(ISqlConnectionFactory factory) : base(factory)
        {
        }
        
        public async Task<bool> ExistsNameAsync(string name)
        {
            const string commandText = @"select exists(select 1 from roles where lower(name) like lower(@name))";
            using var conn = _factory.GetOpenConnection();
            return await conn.ExecuteScalarAsync<bool>(commandText,new {name});
        }
    }
}