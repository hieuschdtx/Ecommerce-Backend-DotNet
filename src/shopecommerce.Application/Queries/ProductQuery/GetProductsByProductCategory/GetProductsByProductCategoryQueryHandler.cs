using Microsoft.AspNetCore.Http;
using shopecommerce.Application.Services.ProductService;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Extensions;
using shopecommerce.Domain.Models;
using shopecommerce.Infrastructure.Configurations;

namespace shopecommerce.Application.Queries.ProductQuery.GetProductsByProductCategory
{
    public class GetProductsByProductCategoryQueryHandler : IQueryHandler<GetProductsByProductCategoryQuery, PagedList<ProductPrices>>
    {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppSetting Setting = new();

        public GetProductsByProductCategoryQueryHandler(IProductService productService, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PagedList<ProductPrices>> Handle(GetProductsByProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetProductsByProductCategory(request.id);

            var data = PagedList<ProductPrices>.ToPagedList(products,
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
