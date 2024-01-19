using Microsoft.EntityFrameworkCore;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Infrastructure.Data;

namespace shopecommerce.Infrastructure.Repositories
{
    public class ProductPriceRepository : IProductPriceRepository
    {
        private readonly EcommerceContext _context;

        public ProductPriceRepository(EcommerceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<ProductsPrices> AddAsync(ProductsPrices entity)
        {
            return (await _context.AddAsync(entity)).Entity;
        }

        public async Task DeleteAsync(ProductsPrices entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<ProductsPrices> GetByIdAsync(string id)
        {
            return await _context.ProductsPrices.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<ProductsPrices> GetProductsPricesByProductId(string productId)
        {
            return await _context.ProductsPrices.FirstOrDefaultAsync(p => p.product_id == productId);
        }

        public async Task UpdateAsync(ProductsPrices entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
        }
    }
}