using Dapper;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.ProductService
{
    public class ProductServiceBase
    {
        protected readonly ISqlConnectionFactory _factory;

        public ProductServiceBase(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<ProductDto>> GetAllProduct()
        {
            const string queryString = @"select * from products";
            using var conn = _factory.GetOpenConnection();
            var data = await conn.QueryAsync<ProductDto>(queryString);
            return data;
        }
    }
}
