using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.UserCommand.SendMailUser
{
    public class SendMailUserCommand : CommandBase<BaseResponseDto>
    {
        public string email { get; set; }
    }
}
