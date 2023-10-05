using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.PromotionCommand.DeletePromotion;

public class DeletePromotionCommand : CommandBase<BaseResponseDto>
{
    public DeletePromotionCommand(string id)
    {
        this.SetId(id);
    }
}