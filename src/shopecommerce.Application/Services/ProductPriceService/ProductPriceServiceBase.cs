using Dapper;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.ProductPriceService
{
    public class ProductPriceServiceBase
    {
        protected readonly ISqlConnectionFactory _factory;

        public ProductPriceServiceBase(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<ProductPriceDto>> GetAllAsync()
        {
            const string queryString = @"select * from products_prices";
            using var conn = _factory.GetOpenConnection();
            return await conn.QueryAsync<ProductPriceDto>(queryString);
        }
    }
}