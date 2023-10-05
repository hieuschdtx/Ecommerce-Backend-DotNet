using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.PromotionService;

public class PromotionService : PromotionServiceBase, IPromotionService
{
    public PromotionService(ISqlConnectionFactory factory) : base(factory)
    {
    }
}
