using FluentValidation;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Commands.ProductCommand.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.id.ToString()).NotEmpty().WithMessage("Product id không được để trống")
                    .Must(IsvalidGuid).WithMessage("Product id không hợp lệ");
            RuleFor(p => p.product_category_id).NotEmpty().WithMessage("Product category id không được để trống")
                    .Must(IsvalidGuid).WithMessage("Product category id không hợp lệ");
        }
        private static bool IsvalidGuid(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return true;
            }
            return BaseGuidEx.IsGuid(id);
        }
    }
}