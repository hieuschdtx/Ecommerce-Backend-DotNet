using FluentValidation;
using shopecommerce.Application.Commands.CategoryCommand;

namespace shopecommerce.Application.Validator
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.name).NotEmpty().WithMessage("Tên không được để trống.");
            RuleFor(p => p.name).MaximumLength(256).WithMessage("Tên không quá 256 kí tự.");
            RuleFor(p => p.description).MaximumLength(256).WithMessage("Mô tả không quá 256 kí tự.");
            RuleFor(p => p.create_by).MaximumLength(256).WithMessage("Tên người tạo không quá 256 kí tự.");
            #endregion
        }
        private bool BeValidGuid( string id )
        {
            // Sử dụng Guid.TryParse để kiểm tra xem chuỗi có thể được chuyển đổi thành Guid hay không.
            Guid result;
            return Guid.TryParse(id, out result);
        }
    }
}
