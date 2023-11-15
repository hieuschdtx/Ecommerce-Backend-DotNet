using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Infrastructure.Data;

namespace shopecommerce.Infrastructure.Repositories
{
    public class SlideRepository : ISlideRepository
    {
        private readonly EcommerceContext _context;
        public SlideRepository(EcommerceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IUnitOfWork UnitOfWork => _context;

        public async Task<Slides> AddAsync(Slides entity)
        {
            return (await _context.AddAsync(entity)).Entity;
        }

        public async Task DeleteAsync(Slides entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<Slides> GetByIdAsync(string id)
        {
            return await _context.Slides.FindAsync(id);
        }

        public async Task UpdateAsync(Slides entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
        }
    }
}
