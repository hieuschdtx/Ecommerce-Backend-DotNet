using Dapper;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.RoleService
{
    public class RoleServiceBase
    {
        protected readonly ISqlConnectionFactory _factory;
        protected RoleServiceBase(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<RoleDto>> GetAllRoleAsync()
        {
            const string commandText = @"select * from roles";
            using var conn = _factory.GetOpenConnection();

            return await conn.QueryAsync<RoleDto>(commandText);
        }
    }
}