using AutoMapper;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.PromotionCommand.CreatePromotion
{
    public class CreatePromotionCommandHandler : ICommandHandler<CreatePromotionCommand, BaseResponseDto>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public CreatePromotionCommandHandler(IPromotionRepository promotionRepository, IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponseDto> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotionMapping = _mapper.Map(request, new Promotions());

            promotionMapping.CreateTime();
            promotionMapping.from_day = promotionMapping.SetDateTimeWithoutTimeZone(promotionMapping.from_day);
            promotionMapping.to_day = promotionMapping.SetDateTimeWithoutTimeZone(promotionMapping.to_day);

            await _promotionRepository.AddAsync(promotionMapping);
            await _promotionRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
            return new BaseResponseDto(true, "Tạo thành công");
        }
    }
}
