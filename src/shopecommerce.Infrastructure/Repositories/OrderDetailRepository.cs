using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
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
