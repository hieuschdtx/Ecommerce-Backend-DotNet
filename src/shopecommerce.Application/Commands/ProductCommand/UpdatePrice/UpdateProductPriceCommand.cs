using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ProductCommand.UpdatePrice
{
    public class UpdateProductPriceCommand : CommandBase<BaseResponseDto>
    {
        public List<ProductPrices> product_price { get; set; }
    }
}