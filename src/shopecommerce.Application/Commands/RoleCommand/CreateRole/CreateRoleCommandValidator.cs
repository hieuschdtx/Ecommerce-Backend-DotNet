using FluentValidation;

namespace shopecommerce.Application.Commands.RoleCommand.CreateRole
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(p => p.name)
                .NotEmpty().WithMessage("Tên quyền người dùng không được để trống")
                .MaximumLength(256).WithMessage("Tên quyền người dùng không quá 256 kí tự");
        }
    }
}