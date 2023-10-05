using FluentValidation;

namespace shopecommerce.Application.Commands.UserCommand.LoginUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(p => p.phone_number)
               .NotEmpty().WithMessage("Số điện thoại không được để trống.")
               .MaximumLength(11).WithMessage("Số điện thoại không hợp lệ.")
               .Matches("^[0-9]*$").WithMessage("Số điện thoại chỉ được nhập số.");

            RuleFor(p => p.password)
                .NotEmpty().WithMessage("Mật khẩu không được để trống.");
        }
    }
}
