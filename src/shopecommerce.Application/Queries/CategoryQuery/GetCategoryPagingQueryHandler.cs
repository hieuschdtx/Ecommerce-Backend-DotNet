using Microsoft.AspNetCore.Http;
using shopecommerce.Application.Services.CategoryService;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;
using shopecommerce.Infrastructure.Configurations;

namespace shopecommerce.Application.Queries.CategoryQuery
{
    public class GetCategoryPagingQueryHandler : IQueryHandler<GetCategoryPagingQuery,PagedList<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public GetCategoryPagingQueryHandler(ICategoryService categoryService,IHttpContextAccessor httpContextAccessor)
        {
            _categoryService = categoryService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PagedList<CategoryDto>> Handle(GetCategoryPagingQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            var data =  PagedList<CategoryDto>.ToPagedList(categories.OrderBy(on=>on.name),
                request.queryStringParameters.pageNumber,
                request.queryStringParameters.pageSize);
            
            PagedList<CategoryDto>.SaveToPagedList(data,_httpContextAccessor);
            return data;
        }
    }
}