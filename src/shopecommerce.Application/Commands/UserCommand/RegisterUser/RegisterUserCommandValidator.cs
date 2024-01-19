using FluentValidation;

namespace shopecommerce.Application.Commands.UserCommand.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public bool RequireNonAlphanumeric { get; set; } = true;
        public bool RequireUppercase { get; set; } = true;
        public int RequiredLength { get; set; } = 8;
        public string messgeErrorPassword() => $"Mật khẩu phải có ít nhất {RequiredLength} ký tự, một ký tự đặc biệt, một ký tự viết hoa.";

        public RegisterUserCommandValidator()
        {
            RuleFor(p => p.email)
                .NotEmpty().WithMessage("Email không được để trống.")
                .MaximumLength(256).WithMessage("Độ dài Email không quá 256 kí tự.")
                .EmailAddress().WithMessage("Email không hợp lệ");

            RuleFor(p => p.password)
                .NotEmpty().WithMessage("Mật khẩu không được để trống.")
                .MinimumLength(RequiredLength).WithMessage(messgeErrorPassword())
                .Matches("[A-Z]").When(p => RequireUppercase).WithMessage(messgeErrorPassword())
                .Matches("[!@#$%^&*()]").When(p => RequireNonAlphanumeric).WithMessage(messgeErrorPassword());

            RuleFor(p => p.confirm_password)
                .NotEmpty().WithMessage("Xác nhận mật khẩu không được để trống.")
                .Equal(p => p.password).WithMessage("Xác nhận mật khẩu không khớp với mật khẩu.");

            RuleFor(p => p.full_name)
                .NotEmpty().WithMessage("Tên người dùng không được để trống.")
                .MaximumLength(256).WithMessage("Độ dài tên người dùng không quá 256 kí tự.");

            RuleFor(p => p.phone_number)
                .NotEmpty().WithMessage("Số điện thoại không được để trống.")
                .MaximumLength(11).WithMessage("Số điện thoại không hợp lệ.")
                .Matches("^[0-9]*$").WithMessage("Số điện thoại chỉ được nhập số.");
        }
    }
}