using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.OrderCommand.DeleteOrder
{
    public class DeleteOrderCommand : CommandBase<BaseResponseDto>
    {
        public DeleteOrderCommand(string id)
        {
            this.SetId(id);
        }
    }
}
