using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.RoleCommand.CreateRole
{
    public class CreateRoleCommand : CommandBase<BaseResponseDto>
    {
        public string name { get; set; }
        public string? description { get; set; }
    }
}