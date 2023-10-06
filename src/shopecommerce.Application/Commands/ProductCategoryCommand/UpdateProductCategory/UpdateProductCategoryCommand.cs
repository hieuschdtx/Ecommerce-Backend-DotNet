using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ProductCategoryCommand.UpdateProductCategory
{
    public class UpdateProductCategoryCommand : CommandBase<BaseResponseDto>
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public string? modified_by { get; set; }
        public string? category_id { get; set; }
        public string? promotion_id { get; set; }
    }
}