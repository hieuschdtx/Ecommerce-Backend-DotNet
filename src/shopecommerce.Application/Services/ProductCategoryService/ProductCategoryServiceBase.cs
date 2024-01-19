using Dapper;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.ProductCategoryService
{
    public class ProductCategoryServiceBase
    {
        protected readonly ISqlConnectionFactory _factory;

        public ProductCategoryServiceBase(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<ProductCategoryDto>> GetAllProductCategory()
        {
            const string queryString = @"select * from product_categories order by display_order asc";
            using var conn = _factory.GetOpenConnection();

            return await conn.QueryAsync<ProductCategoryDto>(queryString);
        }

        public async Task<IEnumerable<ProductCategoryDto>> GetProductCategoryByCategoryId(string id)
        {
            const string queryString = @"select * from product_categories where category_id = @id order by display_order asc";
            using var conn = _factory.GetOpenConnection();
            return await conn.QueryAsync<ProductCategoryDto>(queryString, new { id });
        }
    }
}