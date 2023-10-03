using FluentValidation;
using shopecommerce.Application.Commands.PromotionCommand.UpdatePromotion;

namespace shopecommerce.Application.Validator
{
    public class UpdatePromotionCommandValidator : AbstractValidator<UpdatePromotionCommand>
    {
        public UpdatePromotionCommandValidator()
        {
            RuleFor(p => p.discount).NotEmpty().WithMessage("Giảm giá không được để trống")
                            .GreaterThan(0).WithMessage("Giảm giá phải lớn hơn 0");

            RuleFor(p => p.from_day).NotEmpty().WithMessage("Thời gian không được để trống")
                            .Must(BeValidDateTime).WithMessage("Thời gian không hợp lệ hoặc đã qua thời gian hiện tại");

            RuleFor(p => p.to_day).NotEmpty().WithMessage("Thời gian không được để trống")
                            .Must(BeValidDateTime).WithMessage("Thời gian không hợp lệ hoặc đã qua thời gian hiện tại")
                            .GreaterThan(p => p.from_day).WithMessage("Thời gian kết thúc phải lớn hơn thời gian bắt đầu");

            RuleFor(p => p.modified_by).MaximumLength(256).WithMessage("Người tạo không quá 256 kí tự");
        }

        private bool BeValidDateTime(DateTime from_day)
        {
            if(!DateTime.TryParse(from_day.ToString(), out DateTime parsedDateTime))
            {
                return false;
            }

            return parsedDateTime > DateTime.Now;
        }
    }
}
