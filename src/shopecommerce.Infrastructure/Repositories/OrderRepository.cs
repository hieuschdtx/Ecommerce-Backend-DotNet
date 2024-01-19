using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Infrastructure.Data;

namespace shopecommerce.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EcommerceContext _context;

        public OrderRepository(EcommerceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Orders> AddAsync(Orders entity)
        {
            return (await _context.AddAsync(entity)).Entity;
        }

        public async Task DeleteAsync(Orders entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<Orders> GetByIdAsync(string id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task UpdateAsync(Orders entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
        }
    }
}
