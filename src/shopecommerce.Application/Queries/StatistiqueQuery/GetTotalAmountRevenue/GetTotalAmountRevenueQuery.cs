using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.StatistiqueQuery.GetTotalAmountRevenue
{
    public class GetTotalAmountRevenueQuery : IQuery<BaseResponseDto>
    {
        public int year { get; set; }
        public GetTotalAmountRevenueQuery(int year)
        {
            this.year = year;
        }
    }
}
