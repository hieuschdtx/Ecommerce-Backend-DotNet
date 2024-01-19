using FluentValidation;

namespace shopecommerce.Application.Commands.OrderCommand.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.customer_email).NotEmpty().WithMessage("Email là bắt buộc");
            RuleFor(x => x.customer_phone).NotEmpty().WithMessage("Số điện thoại là bắt buộc");
            RuleFor(x => x.customer_address).NotEmpty().WithMessage("Địa chỉ không được để trống");
            RuleFor(x => x.modified_by).NotEmpty().WithMessage("Người cập nhật là bắt buộc");
            RuleFor(x => x.customer_name).NotEmpty().WithMessage("Tên khách hàng là bắt buồ");
        }
    }
}
