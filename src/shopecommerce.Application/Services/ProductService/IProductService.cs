using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProduct();
        Task<IEnumerable<ProductPrices>> GetProductByProductCategory(string id);
    }
}
