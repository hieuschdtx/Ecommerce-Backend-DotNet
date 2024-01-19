using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.CategoryCommand.DeleteCategory
{
    public class DeleteCategoryCommand : CommandBase<BaseResponseDto>
    {
        public DeleteCategoryCommand(string id)
        {
            category_id = id;
        }
        public string category_id { get; set; }
    }
}
