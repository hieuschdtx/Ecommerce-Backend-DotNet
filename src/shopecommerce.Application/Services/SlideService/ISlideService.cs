using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.SlideService
{
    public interface ISlideService
    {
        Task<IEnumerable<SlideDto>> GetAllSlideAsync();
    }
}
