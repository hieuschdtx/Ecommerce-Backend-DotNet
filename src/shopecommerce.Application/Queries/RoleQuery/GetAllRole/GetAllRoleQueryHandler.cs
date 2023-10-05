using shopecommerce.Application.Services.RoleService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.RoleQuery.GetAllRole
{
    public class GetAllRoleQueryHandler : IQueryHandler<GetAllRoleQuery, IEnumerable<RoleDto>>
    {
        private readonly IRoleService _roleService;

        public GetAllRoleQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<IEnumerable<RoleDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleService.GetAllRoleAsync();
            return roles;
        }
    }
}
