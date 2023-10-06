using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ProductCategoryCommand.CreateProductCategory
{
    public class CreateProductCategoryCommand : CommandBase<BaseResponseDto>
    {
        public string name { get; set; }
        public string description { get; set; }
        public string created_by { get; set; }
        public string category_id { get; set; }
        public string? promotion_id { get; set; }
    }
}