using Microsoft.EntityFrameworkCore;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Infrastructure.Data;

namespace shopecommerce.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly EcommerceContext _context;
        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public RoleRepository(EcommerceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Roles> GetByIdAsync(string id)
        {
            return (await _context.Roles.FirstOrDefaultAsync(x => x.id == id))!;
        }

        public async Task<Roles> AddAsync(Roles entity)
        {
            return (await _context.AddAsync(entity)).Entity;
        }

        public async Task UpdateAsync(Roles entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Roles entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }
    }
}