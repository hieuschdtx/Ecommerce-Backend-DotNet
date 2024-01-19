using shopecommerce.Application.Services.UserService;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.UserCommand.SendMailUser
{
    public class SendMailUserCommandHandler : ICommandHandler<SendMailUserCommand, BaseResponseDto>
    {
        private readonly ISendMailRepository _sendMailRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        public SendMailUserCommandHandler(ISendMailRepository sendMailRepository, IUserRepository userRepository, IUserService userService)
        {
            _sendMailRepository = sendMailRepository;
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task<BaseResponseDto> Handle(SendMailUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.email);
            if(user is null)
            {
                return new BaseResponseDto(false, UserMessages.user_id_is_not_existed, (int)HttpStatusCode.BadRequest);
            }

            var verifyCode = GenerateOTP.OTP();
            MailContent content = new()
            {
                To = request.email,
                Subject = "Xin chào bạn đã đến với MeatDeli",
                Body = "Mã xác minh bạn cần dùng để truy cập vào Tài khoản MeatDeli của mình là: " + verifyCode
            };

            if(!await _sendMailRepository.SendMail(content))
            {
                return new BaseResponseDto(false, "Có lỗi xảy ra trong quá trình gửi email", (int)HttpStatusCode.BadRequest);
            }

            DateTimeOffset futureDateTimeOffset = DateTimeOffset.Now.AddMinutes(2);
            var futureTimestamp = futureDateTimeOffset.ToUnixTimeSeconds();

            user.SetVerifyCodeExp(verifyCode, futureTimestamp);
            await _userRepository.UpdateAsync(user);
            await _userRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Gửi thành công", (int)HttpStatusCode.OK);
        }

    }
}
