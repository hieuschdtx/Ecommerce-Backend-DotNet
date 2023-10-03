using Microsoft.EntityFrameworkCore;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Infrastructure.Data;

namespace shopecommerce.Infrastructure.Repositories
{
    public class ColorRepository : IColorRepository
    {
        private readonly EcommerceContext _context;

        public ColorRepository(EcommerceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Colors> AddAsync(Colors entity)
        {
            return (await _context.AddAsync(entity)).Entity;
        }

        public async Task DeleteAsync(Colors entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<Colors> GetByIdAsync(string id)
        {
            return await _context.Colors.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task UpdateAsync(Colors entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
        }
    }
}
