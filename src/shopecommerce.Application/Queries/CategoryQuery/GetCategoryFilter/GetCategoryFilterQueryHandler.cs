using Microsoft.AspNetCore.Http;
using shopecommerce.Application.Services.CategoryService;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Extensions;
using shopecommerce.Domain.Models;
using shopecommerce.Infrastructure.Configurations;

namespace shopecommerce.Application.Queries.CategoryQuery.GetCategoryFilter
{
    public class GetCategoryFilterQueryHandler : IQueryHandler<GetCategoryFilterQuery, PagedList<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppSetting Setting = new();

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

            var metadata = new
            {
                data.total_count,
                data.page_size,
                data.current_page,
                data.total_pages,
                data.has_next,
                data.has_previous
            };

            _httpContextAccessor.HttpContext.SetHeaderValue(Setting.headerKeyStrings.Panigation, metadata.ToJson());

            return data;
        }
    }
}