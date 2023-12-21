using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.StatistiqueQuery.CountOrderFullMonthOfYear
{
    public class CountOrderFullMonthOfYearQuery : IQuery<BaseResponseDto>
    {
        public int month { get; set; }
        public int year { get; set; }
        public CountOrderFullMonthOfYearQuery(int year, int month)
        {
            this.year = year;
            this.month = month;
        }
    }
}
