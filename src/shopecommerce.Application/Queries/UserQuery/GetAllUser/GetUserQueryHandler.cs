using shopecommerce.Application.Services.UserService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.UserQuery.GetAllUser
{
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, IEnumerable<UserDto>>
    {
        private readonly IUserService _userService;

        public GetUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllAsync();
            return users;
        }
    }
}