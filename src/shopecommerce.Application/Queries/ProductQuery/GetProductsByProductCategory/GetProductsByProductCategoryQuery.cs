using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.ProductQuery.GetProductsByProductCategory
{
    public class GetProductsByProductCategoryQuery : IQuery<PagedList<ProductPrices>>
    {
        public string id { get; set; }
        public QueryStringParameters queryStringParameters { get; set; }
        public GetProductsByProductCategoryQuery(string id, QueryStringParameters queryStringParameters)
        {
            this.id = id;
            this.queryStringParameters = queryStringParameters;
        }
    }
}
