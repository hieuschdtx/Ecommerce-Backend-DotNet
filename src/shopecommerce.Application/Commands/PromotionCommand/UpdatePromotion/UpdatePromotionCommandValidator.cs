using FluentValidation;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Commands.PromotionCommand.UpdatePromotion;

public class UpdatePromotionCommandValidator : AbstractValidator<UpdatePromotionCommand>
{
    public UpdatePromotionCommandValidator()
    {
        RuleFor(p => p.id).Must((model, Id) => BaseGuidEx.IsGuid(model.id.ToString()))
                            .WithMessage("Id danh mục không hợp lệ.");

        RuleFor(p => p.discount).GreaterThan(0).WithMessage("Giảm giá phải lớn hơn 0");

        RuleFor(p => p.from_day).Must(BeValidDateTime).WithMessage("Thời gian không hợp lệ hoặc đã qua thời gian hiện tại");

        RuleFor(p => p.to_day).Must(BeValidDateTime).WithMessage("Thời gian không hợp lệ hoặc đã qua thời gian hiện tại")
                            .GreaterThan(p => p.from_day).WithMessage("Thời gian kết thúc phải lớn hơn thời gian bắt đầu");
    }

    private bool BeValidDateTime(DateTime? from_day)
    {
        if (string.IsNullOrEmpty(from_day.ToString()))
        {
            return true;
        }

        if (!DateTime.TryParse(from_day.ToString(), out DateTime parsedDateTime))
        {
            return false;
        }

        return parsedDateTime > DateTime.Now;
    }
}