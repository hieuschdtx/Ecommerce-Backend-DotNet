using FluentValidation;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Commands.RoleCommand.UpdateRole
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(p => p.id).Must((model, Id) => BaseGuidEx.IsGuid(model.id.ToString())).WithMessage("Id danh mục không hợp lệ.");
            RuleFor(p => p.name)
                .NotEmpty().WithMessage("Tên quyền người dùng không được để trống")
                .MaximumLength(256).WithMessage("Tên quyền người dùng không quá 256 kí tự");
        }
    }
}
