using Microsoft.EntityFrameworkCore;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Infrastructure.Data;

namespace shopecommerce.Infrastructure.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly EcommerceContext _context;

        public OrderDetailRepository(EcommerceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<OrderDetails> AddAsync(OrderDetails entity)
        {

            return (await _context.AddAsync(entity)).Entity;
        }

        public async Task DeleteAsync(OrderDetails entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteManyOrderDetailByOrderId(string id)
        {
            var relatedRecords = await _context.OrderDetails.Where(b => b.order_id == id).ToListAsync();
            _context.RemoveRange(relatedRecords);
        }

        public async Task<List<OrderDetailsDto>> GetAllOrderDetailByOrderId(string orderId)
        {
            var orderDetails = await _context.OrderDetails.Where(od => od.order_id == orderId).ToListAsync();
            var orderDetailsDtoList = orderDetails.Select(od => new OrderDetailsDto
            {
                product_id = od.product_id,
                order_id = od.order_id,
                quantity = od.quantity,
                total_amount = od.total_amount
            }).ToList();

            return orderDetailsDtoList;
        }

        public async Task<OrderDetails> GetByIdAsync(string id)
        {
            return await _context.OrderDetails.FindAsync(id);
        }

        public Task UpdateAsync(OrderDetails entity)
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }
    }
}
