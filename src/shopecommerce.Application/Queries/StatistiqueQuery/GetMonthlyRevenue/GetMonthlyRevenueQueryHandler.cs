using shopecommerce.Application.Services.StatistiqueService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;
using System.Net;

namespace shopecommerce.Application.Queries.StatistiqueQuery.GetMonthlyRevenue
{
    public class GetMonthlyRevenueQueryHandler : IQueryHandler<GetMonthlyRevenueQuery, BaseResponseDto>
    {
        private readonly IStatistiqueService _statistiqueService;

        public GetMonthlyRevenueQueryHandler(IStatistiqueService statistiqueService)
        {
            _statistiqueService = statistiqueService;
        }

        public async Task<BaseResponseDto> Handle(GetMonthlyRevenueQuery request, CancellationToken cancellationToken)
        {
            var currentDate = DateTime.Now;
            if(request.month > 0 && request.year <= currentDate.Year && new DateTime(request.year, request.month, 1) <= currentDate)
            {
                var totalAmount = await _statistiqueService.GetMonthlyRevenue(request.month, request.year);
                return new BaseResponseDto(true, "Lấy thành công", (int)HttpStatusCode.OK, new { totalAmount });
            }
            return new BaseResponseDto(false, "Thời gian không hợp lệ", (int)HttpStatusCode.BadRequest);
        }
    }
}
