using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.OrderQuery.FilterOrderDetail
{
    public class FilterOrderDetailQuery : IQuery<IEnumerable<OrderDetailDto>>
    {
        public string id { get; set; }
        public FilterOrderDetailQuery(string id)
        {
            this.id = id;
        }
    }
}
