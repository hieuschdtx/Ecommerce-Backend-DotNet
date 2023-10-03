using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.ColorService
{
    public interface IColorService
    {
        Task<bool> CheckNameExists(string name);
        Task<IEnumerable<ColorDto>> GetAllAsync();
    }
}
