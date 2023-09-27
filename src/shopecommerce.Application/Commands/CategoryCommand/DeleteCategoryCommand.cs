using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.CategoryCommand
{
    public class DeleteCategoryCommand : CommandBase<BaseResponseDto>
    {
        public DeleteCategoryCommand(string id)
        {
            this.category_id = id;
        }
        public string category_id { get; set; }
    }
}
