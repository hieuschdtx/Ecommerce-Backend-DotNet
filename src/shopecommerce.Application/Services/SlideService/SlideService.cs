using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.SlideService
{
    public class SlideService : SlideServiceBase, ISlideService
    {
        public SlideService(ISqlConnectionFactory factory) : base(factory)
        {
        }
    }
}
