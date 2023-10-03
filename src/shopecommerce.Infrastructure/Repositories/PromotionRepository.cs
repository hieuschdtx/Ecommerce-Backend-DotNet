using Microsoft.EntityFrameworkCore;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Infrastructure.Data;

namespace shopecommerce.Infrastructure.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly EcommerceContext _context;

        public PromotionRepository(EcommerceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Promotions> AddAsync(Promotions entity)
        {
            return (await _context.AddAsync(entity)).Entity;
        }

        public Task DeleteAsync(Promotions entity)
        {
            _context.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<Promotions> GetByIdAsync(string id)
        {
            return await _context.Promotions.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task UpdateAsync(Promotions entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
        }
    }
}
