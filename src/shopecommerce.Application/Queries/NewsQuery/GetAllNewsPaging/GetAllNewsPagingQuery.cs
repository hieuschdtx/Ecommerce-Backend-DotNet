using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.NewsQuery.GetAllNewsPaging
{
    public class GetAllNewsPagingQuery : IQuery<PagedList<NewsDto>>
    {
        public GetAllNewsPagingQuery(QueryStringParameters queryStringParameters)
        {
            this.queryStringParameters = queryStringParameters;
        }
        public QueryStringParameters queryStringParameters { get; set; }
    }
}
