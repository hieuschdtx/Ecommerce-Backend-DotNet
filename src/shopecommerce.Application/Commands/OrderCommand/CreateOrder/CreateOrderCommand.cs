using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;
namespace shopecommerce.Application.Commands.OrderCommand.CreateOrder
{
    public class CreateOrderCommand : CommandBase<BaseResponseDto>
    {
        public string customer_name { get; set; }
        public string customer_address { get; set; }
        public string customer_email { get; set; }
        public string customer_phone { get; set; }
        public string? note { get; set; }
        public bool request_invoice { get; set; }
        public DateTime delivery_date { get; set; }
        public decimal bill_invoice { get; set; }
        public int payment_methods_id { get; set; }
        public List<ProductCart> carts { get; set; }
        public string? userId { get; set; }
        public int status { get; set; } = 1;
        public bool payment_status { get; set; } = false;
    }
    public class ProductCart
    {
        public string product_id { get; set; }
        public int quantity { get; set; }
        public decimal total_amount { get; set; }
    }
}
