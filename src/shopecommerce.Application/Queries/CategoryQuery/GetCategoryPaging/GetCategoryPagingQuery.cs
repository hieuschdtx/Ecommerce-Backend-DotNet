using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.CategoryQuery.GetCategoryPaging
{
    public class GetCategoryPagingQuery : IQuery<PagedList<CategoryDto>>
    {
        public GetCategoryPagingQuery(QueryStringParameters queryStringParameters)
        {
            this.queryStringParameters = queryStringParameters;
        }
        public QueryStringParameters queryStringParameters { get; set; }
    }
}