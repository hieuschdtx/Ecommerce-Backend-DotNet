using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ProductCommand.DeleteImageProduct
{
    public class DeleteImageProductCommand : CommandBase<BaseResponseDto>
    {
        public List<string> files_name { get; set; }
    }
}
