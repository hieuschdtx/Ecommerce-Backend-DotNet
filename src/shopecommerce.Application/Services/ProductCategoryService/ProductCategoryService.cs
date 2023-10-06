using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.ProductCategoryService
{
    public class ProductCategoryService : ProductCategoryServiceBase, IProductCategoryService
    {
        public ProductCategoryService(ISqlConnectionFactory factory) : base(factory)
        {
        }
    }
}