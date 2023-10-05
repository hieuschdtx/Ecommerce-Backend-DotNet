using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.RoleCommand.DeleteRole
{
    public class DeleteRoleCommand : CommandBase<BaseResponseDto>
    {
        public DeleteRoleCommand(string id)
        {
            SetId(id);
        }
    }
}
