using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.UserCommand.LogoutUser
{
    public class LogoutUserCommand : CommandBase<BaseResponseDto>
    {
        public string refresh_token { get; set; }
    }
}
