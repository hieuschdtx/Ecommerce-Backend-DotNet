using FluentValidation;

namespace shopecommerce.Application.Commands.PromotionCommand.CreatePromotion
{
    public class CreatePromotionCommandValidator : AbstractValidator<CreatePromotionCommand>
    {
        public CreatePromotionCommandValidator()
        {
            RuleFor(p => p.name).NotEmpty().WithMessage("Tên Không được để trống");

            RuleFor(p => p.discount).NotEmpty().WithMessage("Giảm giá không được để trống");

            RuleFor(p => p.from_day).NotEmpty().WithMessage("Thời gian không được để trống");

            RuleFor(p => p.to_day).NotEmpty().WithMessage("Thời gian không được để trống");
        }
    }
}
