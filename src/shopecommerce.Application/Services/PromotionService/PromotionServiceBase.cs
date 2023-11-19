using Dapper;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.PromotionService;

public class PromotionServiceBase
{
    private readonly ISqlConnectionFactory _factory;

    public PromotionServiceBase(ISqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<PromotionDto>> GetAllAsync()
    {
        const string queryString = @"select * from promotions order by discount asc";
        using var conn = _factory.GetOpenConnection();
        return await conn.QueryAsync<PromotionDto>(queryString);
    }

    public async Task<int> GetDisCount(string promotionId)
    {
        const string queryString = @"select discount from promotions where id = @promotionId";
        using var conn = _factory.GetOpenConnection();
        return await conn.QueryFirstOrDefaultAsync<int>(queryString, new { promotionId });
    }

    public async Task<PromotionDto> GetPromotionByProductId(string productId)
    {
        const string queryString = @"select pro.* from product_categories pc join products p on pc.id = p.product_category_id join promotions pro on pc.promotion_id = pro.id where p.id = @productId";
        using var conn = _factory.GetOpenConnection();
        return await conn.QueryFirstOrDefaultAsync<PromotionDto>(queryString, new { productId });
    }
}