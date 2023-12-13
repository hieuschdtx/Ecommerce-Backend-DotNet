using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.OrderService
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrderAsync();
        Task<IEnumerable<OrderDetailDto>> FilterOrderDetail(string id);
        Task<OrderDto> GetOrderByIdAsync(string id);
    }
}
