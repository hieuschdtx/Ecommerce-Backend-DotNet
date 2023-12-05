using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.ProductQuery.GetProductPaging
{
    public class GetProductPagingQuery : IQuery<PagedList<ProductPrices>>
    {
        public QueryStringParameters queryStringParameters { get; set; }
        public GetProductPagingQuery(QueryStringParameters queryStringParameters)
        {
            this.queryStringParameters = queryStringParameters;
        }
    }
}
