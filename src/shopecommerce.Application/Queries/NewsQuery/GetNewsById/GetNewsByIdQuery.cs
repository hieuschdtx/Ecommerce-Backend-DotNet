using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.NewsQuery.GetNewsById
{
    public class GetNewsByIdQuery : IQuery<NewsDto>
    {
        public string id { get; set; }
        public GetNewsByIdQuery(string id)
        {
            this.id = id;
        }
    }
}
