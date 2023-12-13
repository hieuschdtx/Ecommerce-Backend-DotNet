using shopecommerce.Application.Services.OrderService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using System.Net;

namespace shopecommerce.Application.Queries.OrderQuery.GetOrderById
{
    public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderService _orderService;

        public GetOrderByIdQueryHandler(IOrderService orderService, IOrderRepository orderRepository)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            if(await _orderRepository.GetByIdAsync(request.id) is null)
            {
                throw new BusinessRuleException("400", "Không tồn tại đơn hàng", HttpStatusCode.BadRequest);
            }

            return await _orderService.GetOrderByIdAsync(request.id);
        }
    }
}
