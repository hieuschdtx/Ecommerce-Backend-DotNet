using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.ProductPriceService
{
    public class ProductPriceService : ProductPriceServiceBase, IProductPriceService
    {
        public ProductPriceService(ISqlConnectionFactory factory) : base(factory)
        {
        }
    }
}