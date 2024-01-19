using FluentValidation;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Commands.PromotionCommand.UpdatePromotion;

public class UpdatePromotionCommandValidator : AbstractValidator<UpdatePromotionCommand>
{
    public UpdatePromotionCommandValidator()
    {
        RuleFor(p => p.id).Must((model, Id) => BaseGuidEx.IsGuid(model.id.ToString()))
                            .WithMessage("Id danh mục không hợp lệ.");

        RuleFor(p => p.to_day).GreaterThan(p => p.from_day).WithMessage("Thời gian kết thúc phải lớn hơn thời gian bắt đầu");
    }
}