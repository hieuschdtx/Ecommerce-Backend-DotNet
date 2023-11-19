using shopecommerce.Application.Services.ProductCategoryService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.ProductCategoryQuery.GetProductCategoriesByCategoryId
{
    public class GetProductCategoriesByCategoryIdQueryHandler : IQueryHandler<GetProductCategoriesByCategoryIdQuery, IEnumerable<ProductCategoryDto>>
    {
        private readonly IProductCategoryService _productCategoryService;

        public GetProductCategoriesByCategoryIdQueryHandler(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        public async Task<IEnumerable<ProductCategoryDto>> Handle(GetProductCategoriesByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            return await _productCategoryService.GetProductCategoryByCategoryId(request.id);
        }
    }
}
