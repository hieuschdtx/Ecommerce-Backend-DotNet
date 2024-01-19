using FluentValidation;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Commands.CategoryCommand.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            #region Generated Constructor
            RuleFor(p => p.id).Must((model, Id) => BaseGuidEx.IsGuid(model.id.ToString())).WithMessage("Id danh mục không hợp lệ.");
            RuleFor(p => p.id).NotEmpty().WithMessage("Mã danh mục không được để trống.");
            RuleFor(p => p.name).NotEmpty().WithMessage("Tên danh mục không được để trống.");
            RuleFor(p => p.name).MaximumLength(256).WithMessage("Tên danh mục không quá 256 kí tự.");
            RuleFor(p => p.description).MaximumLength(256).WithMessage("Mô tả không quá 256 kí tự.");
            RuleFor(p => p.modified_by).MaximumLength(256).WithMessage("Người chỉnh sửa không quá 256 kí tự.");
            #endregion
        }
    }
}
