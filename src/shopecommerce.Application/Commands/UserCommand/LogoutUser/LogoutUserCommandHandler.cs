using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.UserCommand.LogoutUser
{
    public class LogoutUserCommandHandler : ICommandHandler<LogoutUserCommand, BaseResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public LogoutUserCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<BaseResponseDto> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.id.ToString());
            if(user == null)
            {
                return new BaseResponseDto(false, UserMessages.unauthorized, (int)HttpStatusCode.Unauthorized);
            }

            if(!string.Equals(request.refresh_token, user.refresh_token))
            {
                return new BaseResponseDto(false, UserMessages.unauthorized, (int)HttpStatusCode.Unauthorized);
            }

            //signout session
            await _jwtProvider.SignOutAsync();
            user.SetLockoutEnd();
            await _userRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Đăng xuất thành công", (int)HttpStatusCode.OK);
        }
    }
}
