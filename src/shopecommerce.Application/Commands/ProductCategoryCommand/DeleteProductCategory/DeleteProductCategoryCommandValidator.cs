using FluentValidation;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Commands.ProductCategoryCommand.DeleteProductCategory
{
    public class DeleteProductCategoryCommandValidator : AbstractValidator<DeleteProductCategoryCommand>
    {
        public DeleteProductCategoryCommandValidator()
        {
            RuleFor(p => p.id.ToString()).Must(BaseGuidEx.BeValidGuid).WithMessage("Product Category Id không hợp lệ");
        }
    }
}