using FluentValidation;
using shopecommerce.Application.Commands.RoleCommand;

namespace shopecommerce.Application.Validator
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(p => p.name)
                .NotEmpty().WithMessage("Tên quyền người dùng không được để trống")
                .MaximumLength(256).WithMessage("Tên quyền người dùng không quá 256 kí tự");
        }
    }
}
