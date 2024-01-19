using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ProductCommand.CreatePrice
{
    public class CreatePriceCommand : CommandBase<BaseResponseDto>
    {
        public List<PriceWeightCreate> prices { get; set; }
    }

    public class PriceWeightCreate
    {
        public decimal weight { get; set; }
        public decimal price { get; set; }
    }
}