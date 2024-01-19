using shopecommerce.Application.Services.PromotionService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.PromotionQuery.GetAllPromotion;

public class GetAllPromotionQueryHandler : IQueryHandler<GetAllPromotionQuery, IEnumerable<PromotionDto>>
{
    private readonly IPromotionService _promotionService;

    public GetAllPromotionQueryHandler(IPromotionService promotionService)
    {
        _promotionService = promotionService;
    }

    public async Task<IEnumerable<PromotionDto>> Handle(GetAllPromotionQuery request, CancellationToken cancellationToken)
    {
        return await _promotionService.GetAllAsync();
    }
}
