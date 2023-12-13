using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.OrderService
{
    public class OrderService : OrderServiceBase, IOrderService
    {
        public OrderService(ISqlConnectionFactory factory) : base(factory)
        {
        }
    }
}
