using Dapper;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.NewsService
{
    public class NewsServiceBase
    {
        protected readonly ISqlConnectionFactory _factory;

        public NewsServiceBase(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<NewsDto>> GetAllNewsListAsync()
        {
            const string queryString = @"select * from news order by created_at desc";
            using var conn = _factory.GetOpenConnection();
            return await conn.QueryAsync<NewsDto>(queryString);
        }
    }
}
