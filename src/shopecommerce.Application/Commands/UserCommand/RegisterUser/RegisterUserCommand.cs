using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Consts;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.UserCommand.RegisterUser;

public class RegisterUserCommand : CommandBase<BaseResponseDto>
{
    public string full_name { get; set; }
    public string phone_number { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string confirm_password { get; set; }
    public string name_role { get; set; } = RoleConst.Guest;
}