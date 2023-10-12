using FluentValidation;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Commands.ProductCommand.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.name).NotEmpty().WithMessage("Tên không được để trống");

            RuleFor(p => p.stock).GreaterThan(0).WithMessage("Số lượng không được bé hơn 0");

            RuleFor(p => p.product_category_id).NotEmpty().WithMessage("Product category id không được để trống")
                        .Must(IsvalidGuid).WithMessage("Product category id không hợp lệ");

            RuleFor(p => p.promotion_id).Must(IsvalidGuid).WithMessage("Promotion id không hợp lệ");
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