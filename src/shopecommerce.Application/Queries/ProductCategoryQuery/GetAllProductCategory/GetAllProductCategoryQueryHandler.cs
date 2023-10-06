using shopecommerce.Application.Services.ProductCategoryService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.ProductCategoryQuery.GetAllProductCategory
{
    public class GetAllProductCategoryQueryHandler : IQueryHandler<GetAllProductCategoryQuery, IEnumerable<ProductCategoryDto>>
    {
        private readonly IProductCategoryService _productCategoryService;

        public GetAllProductCategoryQueryHandler(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        public async Task<IEnumerable<ProductCategoryDto>> Handle(GetAllProductCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _productCategoryService.GetAllProductCategory();
        }
    }
}