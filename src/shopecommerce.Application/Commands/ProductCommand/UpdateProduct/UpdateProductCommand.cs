using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ProductCommand.UpdateProduct
{
    public class UpdateProductCommand : CommandBase<BaseResponseDto>
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public string? detail { get; set; }
        public bool? status { get; set; }
        public bool? home_flag { get; set; }
        public bool? hot_flag { get; set; }
        public string? modified_by { get; set; }
        public int? stock { get; set; }
        public string product_category_id { get; set; }
        public string? origin { get; set; }
        public string? storage { get; set; }
    }
}