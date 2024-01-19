using Microsoft.EntityFrameworkCore;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Infrastructure.Data;

namespace shopecommerce.Infrastructure.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly EcommerceContext _context;
        public NewsRepository(EcommerceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<News> AddAsync(News entity)
        {
            return (await _context.News.AddAsync(entity)).Entity;
        }

        public async Task DeleteAsync(News entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<News> GetByIdAsync(string id)
        {
            return await _context.News.FindAsync(id);
        }

        public async Task UpdateAsync(News entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
        }
    }
}
