using FluentValidation;

namespace shopecommerce.Application.Commands.OrderCommand.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.customer_name).NotEmpty().WithMessage("Tên khách hàng không được để trống");
            RuleFor(x => x.customer_address).NotEmpty().WithMessage("Địa chỉ không được để trống");
            RuleFor(x => x.customer_email).NotEmpty().WithMessage("Địa chỉ email không được để trống");
            RuleFor(x => x.customer_phone).NotEmpty().WithMessage("Số điện thoại không được để trống");
            RuleFor(x => x.bill_invoice).NotEmpty().WithMessage("Giá trị đơn không được để trống");
            RuleFor(x => x.bill_invoice).GreaterThan(0).WithMessage("Giá trị hóa đơn không được nhỏ hơn 0");
            RuleFor(x => x.delivery_date).GreaterThan(new DateTime()).WithMessage("Thời gian không được nhỏ hơn thời gian hiện tại");
        }
    }
}
