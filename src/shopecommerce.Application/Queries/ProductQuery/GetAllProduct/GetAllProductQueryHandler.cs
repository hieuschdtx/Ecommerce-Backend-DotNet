using shopecommerce.Application.Services.ProductService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.ProductQuery.GetAllProduct
{
    public class GetAllProductQueryHandler : IQueryHandler<GetAllProductQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductService _productService;

        public GetAllProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetAllProduct();
        }
    }
}
