using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.UserCommand.UpdatePassword
{
    public class UpdatePasswordUserCommand : CommandBase<BaseResponseDto>
    {
        public string password { get; set; }
        public string email { get; set; }
    }
}
