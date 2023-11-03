using Microsoft.AspNetCore.SignalR;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.PromotionCommand.DeletePromotion;

public class DeletePromotionCommandHandler : ICommandHandler<DeletePromotionCommand, BaseResponseDto>
{
    private readonly IPromotionRepository _promotionRepository;
    private readonly IHubContext<DataHub> _hubContext;

    public DeletePromotionCommandHandler(IPromotionRepository promotionRepository, IHubContext<DataHub> hubContext)
    {
        _promotionRepository = promotionRepository;
        _hubContext = hubContext;
    }

    public async Task<BaseResponseDto> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
    {
        var promotion = await _promotionRepository.GetByIdAsync(request.id.ToString());
        if(promotion == null)
        {
            return new BaseResponseDto(false, PromotionMessages.promotion_id_not_existed, (int)HttpStatusCode.BadRequest);
        }

        await _promotionRepository.DeleteAsync(promotion);
        await _promotionRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

        await _hubContext.Clients.All.SendAsync("RELOAD_DATA_CHANGE", cancellationToken);
        return new BaseResponseDto(true, "Xóa thành công", (int)HttpStatusCode.OK);
    }
}
