using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.OrderCommand.UpdateOrder
{
    public class UpdateOrderCommand : CommandBase<BaseResponseDto>
    {
        public string customer_name { get; set; }
        public string customer_address { get; set; }
        public string customer_email { get; set; }
        public string customer_phone { get; set; }
        public string note { get; set; }
        public bool payment_status { get; set; }
        public int status { get; set; }
        public string modified_by { get; set; }
    }
}
