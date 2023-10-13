using FluentValidation;

namespace shopecommerce.Application.Commands.ProductCommand.UpdatePrice
{
    public class UpdateProductPriceCommandValidator : AbstractValidator<UpdateProductPriceCommand>
    {
        public UpdateProductPriceCommandValidator()
        {
            RuleFor(p => p.product_price).Must(prices => prices != null && prices.All(price => price.price >= 0))
                        .WithMessage("Giá không được để trống và phải lớn hơn hoặc bằng 0");

            RuleFor(p => p.product_price).Must(prices => prices != null && prices.All(price => price.weight > 0))
                        .WithMessage("Cân nặng không được để trống và phải lớn hơn 0");
        }
    }
}