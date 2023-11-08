using shopecommerce.Application.Services.ProductPriceService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.ProductQuery.GetAllProductPrice
{
    public class GetAllProductPriceQueryHandler : IQueryHandler<GetAllProductPriceQuery, IEnumerable<ProductPriceDto>>
    {
        private readonly IProductPriceService _productPriceService;

        public GetAllProductPriceQueryHandler(IProductPriceService productPriceService)
        {
            _productPriceService = productPriceService;
        }

        public async Task<IEnumerable<ProductPriceDto>> Handle(GetAllProductPriceQuery request, CancellationToken cancellationToken)
        {
            return await _productPriceService.GetAllAsync();
        }
    }
}
