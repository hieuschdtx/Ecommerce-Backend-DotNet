using FluentValidation;
using shopecommerce.Application.Commands.PromotionCommand.CreatePromotion;

namespace shopecommerce.Application.Validator
{
    public class CreatePromotionCommandValidator : AbstractValidator<CreatePromotionCommand>
    {
        public CreatePromotionCommandValidator()
        {
            RuleFor(p => p.discount).NotEmpty().WithMessage("Giảm giá không được để trống");
            RuleFor(p => p.from_day).NotEmpty().WithMessage("Thời gian không được để trống");
            RuleFor(p => p.to_day).NotEmpty().WithMessage("Thời gian không được để trống");
            RuleFor(p => p.create_by).MaximumLength(256).WithMessage("Người tạo không quá 256 kí tự");
        }
    }
}
