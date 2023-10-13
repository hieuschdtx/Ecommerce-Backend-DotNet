using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.ProductPriceService
{
    public class ProductPriceServiceBase
    {
        protected readonly ISqlConnectionFactory _factory;

        public ProductPriceServiceBase(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
    }
}