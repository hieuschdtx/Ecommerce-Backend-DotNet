using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ProductCommand.DeleteProduct
{
    public class DeleteProductCommand : CommandBase<BaseResponseDto>
    {
        public DeleteProductCommand(string id)
        {
            this.SetId(id);
        }
    }
}
