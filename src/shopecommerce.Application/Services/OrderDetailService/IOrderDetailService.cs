using shopecommerce.Domain.Entities;

namespace shopecommerce.Application.Services.OrderDetailService
{
    public interface IOrderDetailService
    {
        Task<bool> AddOrderDetail(OrderDetails orderDetails);
    }
}
