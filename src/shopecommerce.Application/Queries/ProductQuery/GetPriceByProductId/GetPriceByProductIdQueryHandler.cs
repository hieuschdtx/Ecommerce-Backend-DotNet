using shopecommerce.Application.Services.ProductPriceService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.ProductQuery.GetPriceByProductId
{
    public class GetPriceByProductIdQueryHandler : IQueryHandler<GetPriceByProductIdQuery, ProductPriceDto>
    {
        private readonly IProductPriceService _productPriceService;

        public GetPriceByProductIdQueryHandler(IProductPriceService productPriceService)
        {
            _productPriceService = productPriceService;
        }

        public async Task<ProductPriceDto> Handle(GetPriceByProductIdQuery request, CancellationToken cancellationToken)
        {
            return await _productPriceService.GetPriceByProductIdAsync(request.id.ToString());
        }
    }
}
