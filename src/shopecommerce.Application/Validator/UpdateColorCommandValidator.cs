using FluentValidation;
using shopecommerce.Application.Commands.ColorCommand.UpdateColor;

namespace shopecommerce.Application.Validator
{
    public class UpdateColorCommandValidator : AbstractValidator<UpdateColorCommand>
    {
        public UpdateColorCommandValidator()
        {
            RuleFor(p => p.name).NotEmpty().WithMessage("Tên không được để trống");
            RuleFor(p => p.name).MaximumLength(256).WithMessage("Mô tả không quá 256 kí tự");
            RuleFor(p => p.modified_by).MaximumLength(256).WithMessage("Tên người tạo không quá 256 kí tự");
        }
    }
}
