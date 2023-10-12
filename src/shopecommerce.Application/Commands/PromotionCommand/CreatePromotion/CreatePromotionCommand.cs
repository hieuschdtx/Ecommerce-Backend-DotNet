using shopecommerce.Domain.Models;
using shopecommerce.Domain.Commons.Commands;

namespace shopecommerce.Application.Commands.PromotionCommand.CreatePromotion
{
    public class CreatePromotionCommand : CommandBase<BaseResponseDto>
    {
        public string name { get; set; }
        public int discount { get; set; }
        public DateTime from_day { get; set; }
        public DateTime to_day { get; set; }
        public bool? status { get; set; }
        public string? created_by { get; set; }
    }
}
