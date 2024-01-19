using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.UserCommand.LogoutUser
{
    public class LogoutUserCommand : CommandBase<BaseResponseDto>
    {
        public string refresh_token { get; set; }
        public LogoutUserCommand(string id, string refresh_token)
        {
            this.SetId(id);
            this.refresh_token = refresh_token;
        }
    }
}
