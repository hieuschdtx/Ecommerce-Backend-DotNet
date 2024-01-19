using FluentValidation;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Commands.ProductCategoryCommand.UpdateProductCategory
{
    public class UpdateProductCategoryCommandValidator : AbstractValidator<UpdateProductCategoryCommand>
    {
        public UpdateProductCategoryCommandValidator()
        {
            RuleFor(p => p.id.ToString()).NotEmpty().WithMessage("Product Category Id không được để trống").Must(BeValidPromotion).WithMessage("Product Category Id không hợp lệ");

            RuleFor(p => p.category_id).Must(BeValidPromotion).WithMessage("Category Id không hợp lệ");

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