using shopecommerce.Application.Services.UserService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.UserQuery.GetUserById
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserService _userSerivce;

        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userSerivce = userService;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userSerivce.GetByIdAsync(request.id);
        }
    }
}