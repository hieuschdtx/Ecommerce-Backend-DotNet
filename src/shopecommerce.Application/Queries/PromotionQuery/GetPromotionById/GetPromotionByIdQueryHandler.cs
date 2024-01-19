using AutoMapper;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.PromotionQuery.GetPromotionById;

public class GetPromotionByIdQueryHandler : IQueryHandler<GetPromotionByIdQuery, PromotionDto>
{
    private readonly IPromotionRepository _promotionRepository;
    private readonly IMapper _mapper;
    public GetPromotionByIdQueryHandler(IPromotionRepository promotionRepository, IMapper mapper)
    {
        _promotionRepository = promotionRepository;
        _mapper = mapper;
    }

    public async Task<PromotionDto> Handle(GetPromotionByIdQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map(await _promotionRepository.GetByIdAsync(request.id.ToString()), new PromotionDto());
    }
}
