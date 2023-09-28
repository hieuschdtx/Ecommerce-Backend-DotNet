using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.RoleQuery
{
    public class GetRoleByIdQuery : IQuery<RoleDto>
    {
        public GetRoleByIdQuery(string roleId)
        {
            this.id = roleId;
        }
        public string id { get; set; }
    }
}
