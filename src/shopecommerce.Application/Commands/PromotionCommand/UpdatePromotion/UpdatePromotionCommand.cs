using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.PromotionCommand.UpdatePromotion;

public class UpdatePromotionCommand : CommandBase<BaseResponseDto>
{
    public string? name { get; set; }
    public int? discount { get; set; }
    public DateTime? from_day { get; set; }
    public DateTime? to_day { get; set; }
    public bool? status { get; set; }
    public string? modified_by { get; set; }
}