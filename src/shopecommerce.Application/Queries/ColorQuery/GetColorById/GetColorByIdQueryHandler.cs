using AutoMapper;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Queries.ColorQuery.GetColorById
{
    public class GetColorByIdQueryHandler : IQueryHandler<GetColorByIdQuery, ColorDto>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;
        public GetColorByIdQueryHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<ColorDto> Handle(GetColorByIdQuery request, CancellationToken cancellationToken)
        {
            var color = await _colorRepository.GetByIdAsync(request.id.ToString());
            var colorMapping = _mapper.Map<ColorDto>(color);

            return colorMapping ?? throw new BusinessRuleException("color_id_not_existed", ColorMessages.color_id_not_existed);
        }
    }
}
