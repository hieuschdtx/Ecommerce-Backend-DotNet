using FluentValidation;

namespace shopecommerce.Application.Commands.PromotionCommand.CreatePromotion
{
    public class CreatePromotionCommandValidator : AbstractValidator<CreatePromotionCommand>
    {
        public CreatePromotionCommandValidator()
        {
            RuleFor(p => p.name).NotEmpty().WithMessage("Tên Không được để trống");

            RuleFor(p => p.discount).NotEmpty().WithMessage("Giảm giá không được để trống")
                            .GreaterThan(0).WithMessage("Giảm giá phải lớn hơn 0");

            RuleFor(p => p.from_day).NotEmpty().WithMessage("Thời gian không được để trống")
                            .Must(BeValidDateTime).WithMessage("Thời gian không hợp lệ hoặc đã qua thời gian hiện tại");

            RuleFor(p => p.to_day).NotEmpty().WithMessage("Thời gian không được để trống")
                            .Must(BeValidDateTime).WithMessage("Thời gian không hợp lệ hoặc đã qua thời gian hiện tại")
                            .GreaterThan(p => p.from_day).WithMessage("Thời gian kết thúc phải lớn hơn thời gian bắt đầu");
        }
        private bool BeValidDateTime(DateTime from_day)
        {
            if (!DateTime.TryParse(from_day.ToString(), out DateTime parsedDateTime))
            {
                return false;
            }

            return parsedDateTime > DateTime.Now;
        }
    }
}
