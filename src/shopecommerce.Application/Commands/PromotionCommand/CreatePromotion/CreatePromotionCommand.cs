using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.PromotionCommand.CreatePromotion
{
    public class CreatePromotionCommand : CommandBase<BaseResponseDto>
    {
        public string? description { get; set; }
        public int discount { get; set; }
        public DateTime from_day { get; set; }
        public DateTime to_day { get; set; }
        public string? create_by { get; set; }
    }
}
