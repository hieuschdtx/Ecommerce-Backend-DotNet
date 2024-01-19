using shopecommerce.Application.Services.OrderService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.OrderQuery.GetAllOrder
{
    public class GetAllOrderQueryHandler : IQueryHandler<GetAllOrderQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderService _orderService;

        public GetAllOrderQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            return await _orderService.GetAllOrderAsync();
        }
    }
}
