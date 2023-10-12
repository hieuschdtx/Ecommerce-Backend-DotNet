using FluentValidation;
using shopecommerce.Application.Commands.ProductCommand.CreateProduct;

namespace shopecommerce.Application.Commands.ProductCommand
{
    public class ProductPriceCommandValidator : AbstractValidator<Prices>
    {
        public ProductPriceCommandValidator()
        {
            RuleFor(p => p.weight).NotEmpty().WithMessage("Số lượng không được để trống").
                        GreaterThan(0).WithMessage("Số lượng không thể bé hơn 0");

            RuleFor(p => p.price).NotEmpty().WithMessage("Số lượng không được để trống").
                        GreaterThan(0).WithMessage("Số lượng không thể bé hơn 0");
        }
    }
}