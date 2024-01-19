using Microsoft.EntityFrameworkCore;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Infrastructure.Data;
namespace shopecommerce.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly EcommerceContext _context;
        public ProductCategoryRepository(EcommerceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<ProductCategories> AddAsync(ProductCategories entity)
        {
            return (await _context.AddAsync(entity)).Entity;
        }

        public async Task DeleteAsync(ProductCategories entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<ProductCategories> GetByIdAsync(string id)
        {
            return await _context.ProductCategories.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task UpdateAsync(ProductCategories entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
        }
    }
}