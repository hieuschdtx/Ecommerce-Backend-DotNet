using shopecommerce.Application.Services.ColorService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.ColorQuery.GetAllColor
{
    public class GetAllColorQueryHandler : IQueryHandler<GetAllColorQuery, IEnumerable<ColorDto>>
    {
        private readonly IColorService _colorService;

        public GetAllColorQueryHandler(IColorService colorService)
        {
            _colorService = colorService;
        }

        public async Task<IEnumerable<ColorDto>> Handle(GetAllColorQuery request, CancellationToken cancellationToken)
        {
            var colors = await _colorService.GetAllAsync();
            return colors;
        }
    }
}
