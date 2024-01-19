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

        public async Task<IEnumerable<ProductPrices>> GetProductByProductCategory()
        {
            const string queryString = @"select p.*,pp.weight,pp.price,pp.price_sale,pp.id price_id, pro.discount from products p 
                                        join product_categories pc on p.product_category_id = pc.id
                                        join products_prices pp on p.id = pp.product_id
                                        join promotions pro on p.promotion_id = pro.id";
            using var conn = _factory.GetOpenConnection();
            return await conn.QueryAsync<ProductPrices>(queryString);
        }

        public async Task<IEnumerable<ProductPrices>> GetProductsByProductCategory(string productCategoryId)
        {
            const string queryString = @"select p.*,pp.weight,pp.price,pp.price_sale,pp.id price_id, pro.discount from products p 
                                        join product_categories pc on p.product_category_id = pc.id
                                        join products_prices pp on p.id = pp.product_id
                                        join promotions pro on p.promotion_id = pro.id
										where pc.id = @productCategoryId
										order by pp.price_sale desc";
            using var conn = _factory.GetOpenConnection();
            return await conn.QueryAsync<ProductPrices>(queryString, new { productCategoryId });
        }
    }
}
