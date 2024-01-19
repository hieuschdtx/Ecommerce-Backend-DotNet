using FluentValidation;

namespace shopecommerce.Application.Commands.NewsCommand.CreateNews
{
    public class CreateNewsCommandValidator : AbstractValidator<CreateNewsCommand>
    {
        public CreateNewsCommandValidator()
        {
            RuleFor(p => p.name).NotEmpty().WithMessage("Tên không được để trống.");
            RuleFor(p => p.name).MaximumLength(256).WithMessage("Tên không quá 256 kí tự.");
            RuleFor(p => p.description).MaximumLength(256).WithMessage("Mô tả không quá 256 kí tự.");
            RuleFor(p => p.created_by).MaximumLength(256).WithMessage("Tên người tạo không quá 256 kí tự.");
        }
    }
}
