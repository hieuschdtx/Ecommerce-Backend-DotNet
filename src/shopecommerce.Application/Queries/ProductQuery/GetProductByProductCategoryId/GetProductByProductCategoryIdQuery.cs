using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.ProductQuery.GetProductByProductCategoryId
{
    public class GetProductByProductCategoryIdQuery : IQuery<IEnumerable<ProductPrices>>
    {
        public GetProductByProductCategoryIdQuery(string id)
        {
            this.id = id;
        }
        public string id { get; set; }
    }
}
