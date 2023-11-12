using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ProductCommand.UpdatePrice
{
    public class UpdateProductPriceCommand : CommandBase<BaseResponseDto>
    {
        public decimal weight { get; set; }
        public decimal price { get; set; }
    }
}