using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Models;

namespace shopecommerce.Domain.Interfaces
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetails>
    {
        Task<List<OrderDetailsDto>> GetAllOrderDetailByOrderId(string orderId);
        Task DeleteManyOrderDetailByOrderId(string id);
    }
}
