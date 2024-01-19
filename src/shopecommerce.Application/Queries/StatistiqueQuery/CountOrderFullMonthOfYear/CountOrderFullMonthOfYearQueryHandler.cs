using shopecommerce.Application.Services.StatistiqueService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;
using System.Net;

namespace shopecommerce.Application.Queries.StatistiqueQuery.CountOrderFullMonthOfYear
{
    public class CountOrderFullMonthOfYearQueryHandler : IQueryHandler<CountOrderFullMonthOfYearQuery, BaseResponseDto>
    {
        private readonly IStatistiqueService _statistiqueService;

        public CountOrderFullMonthOfYearQueryHandler(IStatistiqueService statistiqueService)
        {
            _statistiqueService = statistiqueService;
        }
        public async Task<BaseResponseDto> Handle(CountOrderFullMonthOfYearQuery request, CancellationToken cancellationToken)
        {
            var result = await _statistiqueService.CountOrderFullMonthOfYear(request.year, request.month);
            return new BaseResponseDto(true, "Lấy thành công", (int)HttpStatusCode.OK, result);
        }
    }
}
