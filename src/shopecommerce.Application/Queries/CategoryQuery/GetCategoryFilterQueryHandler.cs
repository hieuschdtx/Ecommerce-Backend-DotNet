using Microsoft.AspNetCore.Http;
using shopecommerce.Application.Services.CategoryService;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.CategoryQuery
{
    public class GetCategoryFilterQueryHandler  : IQueryHandler<GetCategoryFilterQuery,PagedList<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetCategoryFilterQueryHandler(ICategoryService categoryService, IHttpContextAccessor httpContextAccessor)
        {
            _categoryService = categoryService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PagedList<CategoryDto>> Handle(GetCategoryFilterQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetCategoryFilterAsync(request.search_term);
            var data = PagedList<CategoryDto>.ToPagedList(categories.OrderBy(on => on.name),
                request.queryStringParameters.pageNumber,
                request.queryStringParameters.pageSize);
            PagedList<CategoryDto>.SaveToPagedList(data,_httpContextAccessor);

            return data;
        }
    }
}