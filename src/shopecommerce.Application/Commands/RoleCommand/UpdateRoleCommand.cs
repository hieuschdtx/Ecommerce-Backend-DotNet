using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.RoleCommand
{
    public class UpdateRoleCommand : CommandBase<BaseResponseDto>
    {
        public string? description { get; set; }

        public string name { get; set; }
    }
}
