using Microsoft.EntityFrameworkCore;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Infrastructure.Data;

namespace shopecommerce.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly EcommerceContext _context;

    public CategoryRepository(EcommerceContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<Categories> GetByIdAsync(string id)
    {
        return (await _context.Categories.FirstOrDefaultAsync(x => x.id == id))!;
    }

    public async Task<Categories> AddAsync(Categories entity)
    {
        return (await _context.AddAsync(entity)).Entity;
    }

    public async Task UpdateAsync(Categories entity)
    {
        _context.Update(entity);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Categories entity)
    {
        _context.Remove(entity);
        await Task.CompletedTask;
    }
}