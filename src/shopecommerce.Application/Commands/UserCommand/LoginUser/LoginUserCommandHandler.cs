using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Consts;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.UserCommand.LoginUser
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, BaseResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtProvider _jwtProvider;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _configuration;
        public LoginUserCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider,
            IHttpContextAccessor httpContextAccessor, IRoleRepository roleRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _httpContextAccessor = httpContextAccessor;
            _roleRepository = roleRepository;
            _configuration = configuration;
        }

        public async Task<BaseResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var adminUrl = _configuration.GetSection("AdminUrl")["Url"];
            //check user by phone number
            var user = await _userRepository.GetUserByPhoneNumber(request.phone_number);
            if(user == null)
            {
                return new BaseResponseDto(false, UserMessages.user_phone_number_is_not_existed, (int)HttpStatusCode.BadRequest);
            }

            //check password
            if(!PasswordHasher.VerifyPassword(user.password, request.password))
            {
                user.SetLoginFaileCount();
                await _userRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

                return new BaseResponseDto(false, UserMessages.user_password_invalid, (int)HttpStatusCode.BadRequest);
            }


            var hostCall = _httpContextAccessor.HttpContext.Request.Headers["referer"].ToString();
            if(hostCall.Contains(adminUrl))
            {
                var roleUser = await _roleRepository.GetByIdAsync(user.role_id);
                if(roleUser.name.Equals(RoleConst.Guest))
                {
                    return new BaseResponseDto(false, UserMessages.forbidden, (int)HttpStatusCode.Unauthorized);
                }
            }

            //save refreshtoken
            user.SetRefreshToken(_jwtProvider.GenerateRefreshToken());

            // create session
            var accessToken = await _jwtProvider.GenerateAccessTokenAsync(user);

            //save cookie token
            //_jwtProvider.SaveCookiesStorage(accessToken);

            await _userRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
            return new BaseResponseDto(true, "Đăng nhập thành công", (int)HttpStatusCode.OK, accessToken);
        }
    }
}
