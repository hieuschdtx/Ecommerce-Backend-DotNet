using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using System.Net;

namespace shopecommerce.Application.Commands.PromotionCommand.CreatePromotion
{
    public class CreatePromotionCommandHandler : ICommandHandler<CreatePromotionCommand, BaseResponseDto>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<DataHub> _hubContext;

        public CreatePromotionCommandHandler(IPromotionRepository promotionRepository, IMapper mapper, IHubContext<DataHub> hubContext)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        public async Task<BaseResponseDto> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotionMapping = _mapper.Map(request, new Promotions());

            promotionMapping.CreateTime();
            promotionMapping.from_day = promotionMapping.SetDateTimeWithoutTimeZone(promotionMapping.from_day);
            promotionMapping.to_day = promotionMapping.SetDateTimeWithoutTimeZone(promotionMapping.to_day);

            await _promotionRepository.AddAsync(promotionMapping);
            await _promotionRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            await _hubContext.Clients.All.SendAsync("RELOAD_DATA_CHANGE", cancellationToken: cancellationToken);
            return new BaseResponseDto(true, "Tạo thành công", (int)HttpStatusCode.Created);
        }
    }
}
