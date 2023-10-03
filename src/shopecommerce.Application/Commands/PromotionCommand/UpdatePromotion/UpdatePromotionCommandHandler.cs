using AutoMapper;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.PromotionCommand.UpdatePromotion
{
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
                throw new BusinessRuleException("promotion_id_not_existed", PromotionMessages.promotion_id_not_existed);
            }

            var promotionMapping = _mapper.Map(request, promotion);
            promotionMapping.UpdateModifiedTime();

            await _promotionRepository.UpdateAsync(promotion);
            await _promotionRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Cập nhật thành công");
        }
    }
}
