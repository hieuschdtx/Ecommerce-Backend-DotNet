using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.UserService;

public class UserServiceBase
{
    protected readonly ISqlConnectionFactory _factory;

    public UserServiceBase(ISqlConnectionFactory factory)
    {
        _factory = factory;
    }
}