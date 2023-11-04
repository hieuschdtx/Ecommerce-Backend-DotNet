using FluentValidation;

namespace shopecommerce.Application.Commands.PromotionCommand.CreatePromotion
{
    public class CreatePromotionCommandValidator : AbstractValidator<CreatePromotionCommand>
    {
        public CreatePromotionCommandValidator()
        {
            RuleFor(p => p.name).NotEmpty().WithMessage("Tên Không được để trống");

            RuleFor(p => p.discount).Must(x => x >= 0 && x <= 100).WithMessage("Phần trăm được bé hơn 0% hoặc hơn 100%");

            RuleFor(p => p.from_day).NotEmpty().WithMessage("Thời gian không được để trống");

            RuleFor(p => p.to_day).NotEmpty().WithMessage("Thời gian không được để trống");
        }
    }
}
