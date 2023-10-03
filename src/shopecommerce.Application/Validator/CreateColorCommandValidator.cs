using FluentValidation;
using shopecommerce.Application.Commands.ColorCommand.CreateColor;

namespace shopecommerce.Application.Validator
{
    public class CreateColorCommandValidator : AbstractValidator<CreateColorCommand>
    {
        public CreateColorCommandValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.name).NotEmpty().WithMessage("Tên không được để trống");
            RuleFor(p => p.name).MaximumLength(256).WithMessage("Mô tả không quá 256 kí tự");
            RuleFor(p => p.create_by).MaximumLength(256).WithMessage("Tên người tạo không quá 256 kí tự");
            #endregion
        }
    }
}
