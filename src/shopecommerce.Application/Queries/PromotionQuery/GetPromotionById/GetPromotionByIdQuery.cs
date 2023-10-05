using FluentValidation;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.PromotionQuery.GetPromotionById;

public class GetPromotionByIdQuery : IQuery<PromotionDto>
{
    public string id { get; set; }
    public GetPromotionByIdQuery(string id)
    {
        this.id = id;
    }
}

public class GetPromotionByIdQueryValidator : AbstractValidator<GetPromotionByIdQuery>
{
    public GetPromotionByIdQueryValidator()
    {
        RuleFor(p => p.id).NotEmpty().WithMessage("Id không được để trống")
                        .Must((model, Id) => BaseGuidEx.IsGuid(model.id.ToString())).WithMessage("Id không hợp lệ");
    }
}