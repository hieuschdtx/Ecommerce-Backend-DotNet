using shopecommerce.Application.Services.CategoryService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.CategoryQuery.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IQueryHandler<GetAllCategoryQuery, IEnumerable<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;

        public GetAllCategoryQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _categoryService.GetAllCategoryAsync();
        }
    }
}
