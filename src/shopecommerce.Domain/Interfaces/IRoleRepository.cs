using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Domain.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Roles>
    {
        Task<Roles> GetRoleByNameAsync(string name);
    }
}