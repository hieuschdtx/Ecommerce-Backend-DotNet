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
        public async Task<ProductPriceDto> GetPriceByProductIdAsync(string id)
        {
            const string queryString = @"select * from products_prices where product_id = @id";
            using var conn = _factory.GetOpenConnection();
            return await conn.QueryFirstOrDefaultAsync<ProductPriceDto>(queryString, new { id });
        }
    }
}