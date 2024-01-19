using Dapper;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.OrderService
{
    public class OrderServiceBase
    {
        protected readonly ISqlConnectionFactory _factory;

        public OrderServiceBase(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrderAsync()
        {
            const string queryString = @"SELECT orders.*,
                                          COALESCE(u.full_name, null) AS user_name,
                                          COALESCE(u.email, null) AS user_email,
                                          COALESCE(u.phone_number, null) AS user_phone,
                                          COALESCE(u.avatar, null) AS user_avatar
                                        FROM orders
                                        LEFT JOIN users u ON orders.user_id = u.id order by orders.created_at desc";
            using var conn = _factory.GetOpenConnection();
            return await conn.QueryAsync<OrderDto>(queryString);
        }

        public async Task<IEnumerable<OrderDetailDto>> FilterOrderDetail(string id)
        {
            const string queryString = @"select p.name as product_name,p.avatar as product_avatar, pc.name as pc_name, od.*
                                        from orders
                                        join order_details od on orders.id = od.order_id
                                        join products p on p.id = od.product_id
                                        join product_categories pc on pc.id = p.product_category_id
                                        where orders.id = @id";
            using var conn = _factory.GetOpenConnection();
            return await conn.QueryAsync<OrderDetailDto>(queryString, new { id });
        }

        public async Task<OrderDto> GetOrderByIdAsync(string id)
        {
            const string queryString = @"SELECT orders.*,
                                              COALESCE(u.full_name, null) AS user_name,
                                              COALESCE(u.email, null) AS user_email,
                                              COALESCE(u.phone_number, null) AS user_phone,
                                              COALESCE(u.avatar, null) AS user_avatar
                                        FROM orders
                                        LEFT JOIN users u ON orders.user_id = u.id
                                        WHERE orders.id = @id order by orders.created_at desc";
            using var conn = _factory.GetOpenConnection();
            return await conn.QueryFirstOrDefaultAsync<OrderDto>(queryString, new { id });
        }
    }
}
