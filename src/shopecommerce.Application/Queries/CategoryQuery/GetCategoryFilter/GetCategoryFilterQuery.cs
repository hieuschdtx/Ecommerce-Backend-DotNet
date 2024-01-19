using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.CategoryQuery.GetCategoryFilter
{
    public class GetCategoryFilterQuery : IQuery<PagedList<CategoryDto>>
    {
        public GetCategoryFilterQuery(string searchTerm, QueryStringParameters parameters)
        {
            search_term = searchTerm;
            queryStringParameters = parameters;
        }
        public string search_term { get; set; }
        public QueryStringParameters queryStringParameters { get; set; }
    }
}