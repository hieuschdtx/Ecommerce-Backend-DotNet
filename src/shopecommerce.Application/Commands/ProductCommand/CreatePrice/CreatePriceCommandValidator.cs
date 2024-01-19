using FluentValidation;

namespace shopecommerce.Application.Commands.ProductCommand.CreatePrice
{
    public class CreatePriceCommandValidator : AbstractValidator<CreatePriceCommand>
    {
        public CreatePriceCommandValidator()
        {
            RuleFor(p => p.prices).Must(prices => prices != null && prices.All(price => price.price >= 0))
                        .WithMessage("Giá không được để trống và phải lớn hơn hoặc bằng 0");

            RuleFor(p => p.prices).Must(prices => prices != null && prices.All(price => price.weight > 0))
                        .WithMessage("Cân nặng không được để trống và phải lớn hơn 0");
        }
    }
}