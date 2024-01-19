using FluentValidation;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Commands.ProductCommand.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.name).NotEmpty().WithMessage("Tên không được để trống");

            RuleFor(p => p.stock).GreaterThanOrEqualTo(0).WithMessage("Số lượng không được bé hơn 0");

            RuleFor(p => p.product_category_id).NotEmpty().WithMessage("Product category id không được để trống")
                        .Must(IsvalidGuid).WithMessage("Product category id không hợp lệ");

            //RuleFor(p => p.prices).NotEmpty().WithMessage("Giá không được để trống");

            //RuleFor(p => p.prices).Must(prices => prices != null && prices.All(price => price.price >= 0))
            //            .WithMessage("Giá không được để trống và phải lớn hơn hoặc bằng 0");

            //RuleFor(p => p.prices).Must(prices => prices != null && prices.All(price => price.weight > 0))
            //            .WithMessage("Cân nặng không được để trống và phải lớn hơn 0");


        }

        private static bool IsvalidGuid(string? id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return true;
            }
            return BaseGuidEx.IsGuid(id);
        }
    }
}