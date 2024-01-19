using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.ProductService
{
    public class ProductService : ProductServiceBase, IProductService
    {
        public ProductService(ISqlConnectionFactory factory) : base(factory)
        {
        }
    }
}
