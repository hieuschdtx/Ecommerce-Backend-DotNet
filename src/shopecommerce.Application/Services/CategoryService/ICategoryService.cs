using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.CategoryService;

public interface ICategoryService
{
    Task<bool> NameExistsAsync( string name );
    Task<IEnumerable<CategoryDto>> GetAllCategoryAsync();
    Task<IEnumerable<CategoryDto>> GetCategoryFilterAsync(string searchTerm);
}