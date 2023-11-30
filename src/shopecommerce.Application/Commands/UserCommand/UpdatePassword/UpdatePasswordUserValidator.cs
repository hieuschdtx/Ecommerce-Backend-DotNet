using FluentValidation;

namespace shopecommerce.Application.Commands.UserCommand.UpdatePassword
{

    public class UpdatePasswordUserValidator : AbstractValidator<UpdatePasswordUserCommand>
    {
        public bool RequireNonAlphanumeric { get; set; } = true;
        public bool RequireUppercase { get; set; } = true;
        public int RequiredLength { get; set; } = 8;
        public string messgeErrorPassword() => $"Mật khẩu phải có ít nhất {RequiredLength} ký tự, một ký tự đặc biệt, một ký tự viết hoa.";
        public UpdatePasswordUserValidator()
        {
            RuleFor(p => p.password)
                .NotEmpty().WithMessage("Mật khẩu không được để trống.")
                .MinimumLength(RequiredLength).WithMessage(messgeErrorPassword())
                .Matches("[A-Z]").When(p => RequireUppercase).WithMessage(messgeErrorPassword())
                .Matches("[!@#$%^&*()]").When(p => RequireNonAlphanumeric).WithMessage(messgeErrorPassword());
        }
    }
}
