using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.ProductCategoryService
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategoryDto>> GetAllProductCategory();
        Task<IEnumerable<ProductCategoryDto>> GetProductCategoryByCategoryId(string id);
    }
}