using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ContactCommand.DeleteContact
{
    public class DeleteContactCommand : CommandBase<BaseResponseDto>
    {
        public DeleteContactCommand(string id)
        {
            this.SetId(id);
        }
    }
}