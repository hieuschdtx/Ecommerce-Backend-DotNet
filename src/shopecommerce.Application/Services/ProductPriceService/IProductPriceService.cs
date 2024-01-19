using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.ProductPriceService
{
    public interface IProductPriceService
    {
        Task<IEnumerable<ProductPriceDto>> GetAllAsync();
        Task<ProductPriceDto> GetPriceByProductIdAsync(string id);
    }
}