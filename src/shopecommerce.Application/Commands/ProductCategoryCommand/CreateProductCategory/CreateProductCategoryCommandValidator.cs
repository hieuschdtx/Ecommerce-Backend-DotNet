using FluentValidation;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Commands.ProductCategoryCommand.CreateProductCategory
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        public CreateProductCategoryCommandValidator()
        {
            RuleFor(p => p.name).NotEmpty().WithMessage("Tên không được để trống");

            RuleFor(p => p.category_id).NotEmpty().WithMessage("Danh mục không được để trống")
                .Must((model, Id) => BaseGuidEx.IsGuid(model.category_id)).WithMessage("Category Id không hợp lệ");

            RuleFor(p => p.promotion_id).Must(BeValidPromotion).WithMessage("Promotion Id không hợp lệ");
        }
        private static bool BeValidPromotion(string? id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return BaseGuidEx.IsGuid(id);
            }

            return true;
        }
    }
}