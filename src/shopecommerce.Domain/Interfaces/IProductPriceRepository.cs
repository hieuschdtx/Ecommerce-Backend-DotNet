using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Domain.Interfaces
{
    public interface IProductPriceRepository : IGenericRepository<ProductsPrices>
    {
        Task<ProductsPrices> GetProductsPricesByProductId(string productId);
    }
}