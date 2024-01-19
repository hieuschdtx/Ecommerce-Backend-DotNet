using Microsoft.EntityFrameworkCore;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Infrastructure.Data;

namespace shopecommerce.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceContext _context;

        public ProductRepository(EcommerceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Products> AddAsync(Products entity)
        {
            return (await _context.AddAsync(entity)).Entity;
        }

        public async Task DeleteAsync(Products entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<Products> GetByIdAsync(string id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task UpdateAsync(Products entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
        }
    }
}