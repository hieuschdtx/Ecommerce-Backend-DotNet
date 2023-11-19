using Dapper;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.SlideService
{
    public class SlideServiceBase
    {
        protected readonly ISqlConnectionFactory _factory;
        public SlideServiceBase(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<SlideDto>> GetAllSlideAsync()
        {
            const string queryString = @"select * from slides order by display_order asc";
            using var conn = _factory.GetOpenConnection();
            return await conn.QueryAsync<SlideDto>(queryString);
        }
    }
}
