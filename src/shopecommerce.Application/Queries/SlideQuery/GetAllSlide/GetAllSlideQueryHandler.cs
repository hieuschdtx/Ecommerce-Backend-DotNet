using shopecommerce.Application.Services.SlideService;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.SlideQuery.GetAllSlide
{
    public class GetAllSlideQueryHandler : ICommandHandler<GetAllSlideQuery, IEnumerable<SlideDto>>
    {
        private readonly ISlideService _slideService;
        public GetAllSlideQueryHandler(ISlideService slideService)
        {
            _slideService = slideService;
        }

        public async Task<IEnumerable<SlideDto>> Handle(GetAllSlideQuery request, CancellationToken cancellationToken)
        {
            return await _slideService.GetAllSlideAsync();
        }
    }
}
