using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.StatistiqueQuery.GetMonthlyRevenue
{
    public class GetMonthlyRevenueQuery : IQuery<BaseResponseDto>
    {
        public int month { get; set; }
        public int year { get; set; }
    }
}
