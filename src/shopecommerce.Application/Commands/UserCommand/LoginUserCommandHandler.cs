using shopecommerce.Application.Commands.UserCommand.LoginUser;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.UserCommand
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, BaseResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        public LoginUserCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<BaseResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //check user by phone number
            var user = await _userRepository.GetUserByPhoneNumber(request.phone_number);
            if(user == null)
            {
                throw new BusinessRuleException("user_phone_number_is_not_existed", UserMessages.user_phone_number_is_not_existed);
            }
            //check password
            if(!PasswordHasher.VerifyPassword(user.password, request.password))
            {
                user.SetLoginFaileCount();
                await _userRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

                throw new BusinessRuleException("user_password_invalid", UserMessages.user_password_invalid);
            }

            //save refreshtoken
            user.SetRefreshToken(_jwtProvider.GenerateRefreshToken());

            // create session
            var accessToken = await _jwtProvider.GenerateAccessTokenAsync(user);

            //save cookie token
            _jwtProvider.SaveCookiesStorage(accessToken);

            await _userRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
            return new BaseResponseDto(true, "Đăng nhập thành công", accessToken);
        }
    }
}
