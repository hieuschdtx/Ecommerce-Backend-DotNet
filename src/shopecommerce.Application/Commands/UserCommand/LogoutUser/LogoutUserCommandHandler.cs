using shopecommerce.Application.Services.UserService;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.UserCommand.LogoutUser
{
    public class LogoutUserCommandHandler : ICommandHandler<LogoutUserCommand, BaseResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IJwtProvider _jwtProvider;

        public LogoutUserCommandHandler(IUserRepository userRepository, IUserService userService, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _userService = userService;
            _jwtProvider = jwtProvider;
        }

        public async Task<BaseResponseDto> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.id.ToString());
            if(user == null)
            {
                throw new BusinessRuleException("unauthorized", UserMessages.unauthorized);
            }

            if(!string.Equals(request.refresh_token, user.refresh_token))
            {
                throw new BusinessRuleException("unauthorized", UserMessages.unauthorized);
            }

            //signout session
            await _jwtProvider.SignOutAsync();

            return new BaseResponseDto(true, "Đăng xuất thành công");
        }
    }
}
