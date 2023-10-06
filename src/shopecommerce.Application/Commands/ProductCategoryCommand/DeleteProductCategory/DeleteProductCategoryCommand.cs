using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ProductCategoryCommand.DeleteProductCategory
{
    public class DeleteProductCategoryCommand : CommandBase<BaseResponseDto>
    {
        public DeleteProductCategoryCommand(string id)
        {
            this.SetId(id);
        }
    }
}