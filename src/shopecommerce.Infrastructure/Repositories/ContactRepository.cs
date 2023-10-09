using Microsoft.EntityFrameworkCore;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Infrastructure.Data;

namespace shopecommerce.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly EcommerceContext _context;

        public ContactRepository(EcommerceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IUnitOfWork UnitOfWork => _context;

        public async Task<Contacts> AddAsync(Contacts entity)
        {
            return (await _context.AddAsync(entity)).Entity;
        }

        public async Task DeleteAsync(Contacts entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<Contacts> GetByIdAsync(string id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task UpdateAsync(Contacts entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
        }
    }
}