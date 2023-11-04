using AutoMapper;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.PromotionCommand.UpdatePromotion;
public class UpdatePromotionCommandHandler : ICommandHandler<UpdatePromotionCommand, BaseResponseDto>
{
    private readonly IPromotionRepository _promotionRepository;
    private readonly IMapper _mapper;

    public UpdatePromotionCommandHandler(IPromotionRepository promotionRepository, IMapper mapper)
    {
        _promotionRepository = promotionRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponseDto> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
    {
        var promotion = await _promotionRepository.GetByIdAsync(request.id.ToString());
        if(promotion == null)
        {
            return new BaseResponseDto(false, PromotionMessages.promotion_id_not_existed, (int)HttpStatusCode.BadRequest);
        }

        if(string.IsNullOrEmpty(request.from_day.ToString()))
        {
            request.from_day = promotion.from_day;
        }

        if(string.IsNullOrEmpty(request.to_day.ToString()))
        {
            request.to_day = promotion.to_day;
        }

        var promotionMapping = _mapper.Map(request, promotion);
        promotionMapping.UpdateModifiedTime();
        promotionMapping.from_day = promotionMapping.SetDateTimeWithoutTimeZone(promotionMapping.from_day);
        promotionMapping.to_day = promotionMapping.SetDateTimeWithoutTimeZone(promotionMapping.to_day);

        await _promotionRepository.UpdateAsync(promotionMapping);
        await _promotionRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

        return new BaseResponseDto(true, "Cập nhật thành công", (int)HttpStatusCode.OK);
    }
}
