using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ProductCommand.CreatePrice
{
    public class CreatePriceCommand : CommandBase<BaseResponseDto>
    {
        public List<Prices> prices { get; set; }
    }
}