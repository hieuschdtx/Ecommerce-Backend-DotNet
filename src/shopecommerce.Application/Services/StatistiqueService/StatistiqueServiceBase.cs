using Dapper;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.StatistiqueService
{
    public class StatistiqueServiceBase
    {
        private readonly ISqlConnectionFactory _factory;

        public StatistiqueServiceBase(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
        public async Task<decimal> GetMonthlyRevenue(int month, int year)
        {
            var queryString = @"select coalesce(sum(bill_invoice), 0) from orders 
                                where extract(month from created_at) = @month 
                                and extract(year from created_at) = @year
                                and payment_status = true
                                and status = 2";
            using var conn = _factory.GetOpenConnection();
            return await conn.ExecuteScalarAsync<decimal>(queryString, new { month, year });
        }

        public async Task<List<decimal>> GetTotalAmountRevenue(int year)
        {
            var fromDay = new DateOnly(year, 1, 1);
            var toDay = new DateOnly(year, 12, 1);
            const string queryString = @"select coalesce(sum(orders.bill_invoice), 0) as total_amount
                                        from (select extract(month from generate_series(@fromday::date, @today::date, '1 month')) as month) as months
                                        left join
                                        orders on extract(month from orders.created_at) = months.month
                                            and extract(year from orders.created_at) = @year
                                            and orders.payment_status = true
                                            and orders.status = 2
                                        group by months.month
                                        order by months.month";
            using var conn = _factory.GetOpenConnection();
            var parameters = new { year, fromday = fromDay.ToString("yyyy-MM-dd"), today = toDay.ToString("yyyy-MM-dd") };
            return (await conn.QueryAsync<decimal>(queryString, parameters)).ToList();
        }

        public async Task<List<object>> GetCountOrderFollowProCategory()
        {
            const string queryString = @"SELECT pc.name AS category_name, COUNT(od.product_id) AS product_count
                                        FROM order_details od
                                        JOIN products p ON p.id = od.product_id
                                        JOIN product_categories pc ON p.product_category_id = pc.id
                                        GROUP BY pc.id, pc.name";
            using var conn = _factory.GetOpenConnection();
            return (await conn.QueryAsync<object>(queryString)).ToList();
        }

        public async Task<List<object>> CountOrderFullMonthOfYear(int year, int month)
        {
            const string queryString = @"WITH days AS (SELECT generate_series(1, 31) AS day)
                                         SELECT days.day, COALESCE(COUNT(orders.id), 0) AS count_orders
                                         FROM days LEFT JOIN orders 
                                         ON EXTRACT(DAY FROM orders.created_at) = days.day
                                         AND EXTRACT(MONTH FROM orders.created_at) = @month
                                         AND EXTRACT(YEAR FROM orders.created_at) = @year
                                         GROUP BY days.day
                                         ORDER BY days.day";

            using var conn = _factory.GetOpenConnection();
            return (await conn.QueryAsync<object>(queryString, new { year, month })).ToList();
        }
    }
}