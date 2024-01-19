using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.UserCommand.LoginUser
{
    public class LoginUserCommand : CommandBase<BaseResponseDto>
    {
        public string phone_number { get; set; }
        public string password { get; set; }
    }
}
