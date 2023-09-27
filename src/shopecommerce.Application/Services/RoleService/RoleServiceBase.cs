using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.RoleService
{
    public class RoleServiceBase
    {
        protected readonly ISqlConnectionFactory _factory;
        protected RoleServiceBase(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
    }
}