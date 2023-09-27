using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.CategoryQuery
{
    public class GetCategoryFilterQuery : IQuery<PagedList<CategoryDto>>
    {
        public GetCategoryFilterQuery(string searchTerm, QueryStringParameters parameters)
        {
            this.search_term = searchTerm;
            this.queryStringParameters = parameters;
        }
        public string search_term { get; set; }
        public QueryStringParameters queryStringParameters { get; set; }
    }
}