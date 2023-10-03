using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ColorCommand.DeleteColor
{
    public class DeleteColorCommand : CommandBase<BaseResponseDto>
    {
        public DeleteColorCommand(string id)
        {
            this.SetId(id);
        }
    }
}
