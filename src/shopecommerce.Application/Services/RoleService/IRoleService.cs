using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.RoleService
{
    public interface IRoleService
    {
        Task<bool> ExistsNameAsync(string name);
        Task<IEnumerable<RoleDto>> GetAllRoleAsync();
    }
}