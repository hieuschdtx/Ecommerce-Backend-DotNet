using Dapper;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.ColorService
{
    public class ColorService : ColorServiceBase, IColorService
    {
        public ColorService(ISqlConnectionFactory factory) : base(factory)
        {
        }

        public async Task<bool> CheckNameExists(string name)
        {
            const string commandText = @"select exists(select 1 from colors where lower(name) = lower(@name))";
            using var conn = _factory.GetOpenConnection();
            return await conn.ExecuteScalarAsync<bool>(commandText, new { name });
        }
    }
}
