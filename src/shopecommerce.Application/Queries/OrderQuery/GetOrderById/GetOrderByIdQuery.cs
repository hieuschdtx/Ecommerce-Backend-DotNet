using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.OrderQuery.GetOrderById
{
    public class GetOrderByIdQuery : IQuery<OrderDto>
    {
        public string id { get; set; }
        public GetOrderByIdQuery(string id)
        {
            this.id = id;
        }
    }
}
