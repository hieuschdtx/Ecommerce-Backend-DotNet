using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.NewsCommand.DeleteNews
{
    public class DeleteNewsCommand : CommandBase<BaseResponseDto>
    {
        public DeleteNewsCommand(string id)
        {
            SetId(id);
        }
    }
}
