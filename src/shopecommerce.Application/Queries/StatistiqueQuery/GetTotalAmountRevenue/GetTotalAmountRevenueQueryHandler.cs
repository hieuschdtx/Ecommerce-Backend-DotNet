using shopecommerce.Application.Services.StatistiqueService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;
using System.Net;

namespace shopecommerce.Application.Queries.StatistiqueQuery.GetTotalAmountRevenue
{
    public class GetTotalAmountRevenueQueryHandler : IQueryHandler<GetTotalAmountRevenueQuery, BaseResponseDto>
    {
        private readonly IStatistiqueService _statistiqueService;
        public GetTotalAmountRevenueQueryHandler(IStatistiqueService statistiqueService)
        {
            _statistiqueService = statistiqueService;
        }
        public async Task<BaseResponseDto> Handle(GetTotalAmountRevenueQuery request, CancellationToken cancellationToken)
        {
            var result = await _statistiqueService.GetTotalAmountRevenue(request.year);
            return new BaseResponseDto(true, "Lấy thành công", (int)HttpStatusCode.OK, result);
        }
    }
}
