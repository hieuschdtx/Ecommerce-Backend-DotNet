using Dapper;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.ColorService
{
    public class ColorServiceBase
    {
        protected readonly ISqlConnectionFactory _factory;

        public ColorServiceBase(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<ColorDto>> GetAllAsync()
        {
            const string queryText = @"select * from colors";
            using var conn = _factory.GetOpenConnection();
            return await conn.QueryAsync<ColorDto>(queryText);
        }
    }
}
