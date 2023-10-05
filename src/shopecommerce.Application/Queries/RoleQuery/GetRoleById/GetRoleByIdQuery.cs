using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.RoleQuery.GetRoleById
{
    public class GetRoleByIdQuery : IQuery<RoleDto>
    {
        public GetRoleByIdQuery(string roleId)
        {
            id = roleId;
        }
        public string id { get; set; }
    }
}
