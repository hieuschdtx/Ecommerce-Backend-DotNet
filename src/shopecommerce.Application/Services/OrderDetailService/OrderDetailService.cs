using Dapper;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Application.Services.OrderDetailService
{
    public class OrderDetailService : OrderDetailServiceBase, IOrderDetailService
    {
        public OrderDetailService(ISqlConnectionFactory factory) : base(factory)
        {
        }

        public async Task<bool> AddOrderDetail(OrderDetails orderDetails)
        {
            const string commandText = @"insert into order_details (product_id,order_id,quantity,total_amount) values (@product_id,@order_id,@quantity,@total_amount)
                                        ON CONFLICT DO NOTHING";
            var parameters = new
            {
                orderDetails.product_id,
                orderDetails.order_id,
                orderDetails.quantity,
                orderDetails.total_amount,
            };
            using var conn = _factory.GetOpenConnection();
            var rowsAffected = await conn.ExecuteAsync(commandText, parameters);
            bool insertSuccessful = rowsAffected > 0;
            return insertSuccessful;
        }
    }
}
