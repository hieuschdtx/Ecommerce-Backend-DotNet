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

        public Task<Colors> AddAsync(Colors entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Colors entity)
        {
            throw new NotImplementedException();
        }

        public Task<Colors> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Colors entity)
        {
            throw new NotImplementedException();
        }
    }
}
