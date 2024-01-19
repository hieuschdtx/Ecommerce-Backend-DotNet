using shopecommerce.Application.Services.ProductService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.ProductQuery.GetProductByProductCategoryId
{
    public class GetProductByProductCategoryIdQueryHandler : IQueryHandler<GetProductByProductCategoryIdQuery, IEnumerable<ProductPrices>>
    {
        private readonly IProductService _productService;

        public GetProductByProductCategoryIdQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<ProductPrices>> Handle(GetProductByProductCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _productService.GetProductByProductCategory();
            return data;
        }
    }
}
