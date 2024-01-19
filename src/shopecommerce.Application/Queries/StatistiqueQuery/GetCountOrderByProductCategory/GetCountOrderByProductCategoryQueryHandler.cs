using shopecommerce.Application.Services.StatistiqueService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;
using System.Net;

namespace shopecommerce.Application.Queries.StatistiqueQuery.GetCountOrderByProductCategory
{
    public class GetCountOrderByProductCategoryQueryHandler : IQueryHandler<GetCountOrderByProductCategoryQuery, BaseResponseDto>
    {
        private readonly IStatistiqueService _statistiqueService;

        public GetCountOrderByProductCategoryQueryHandler(IStatistiqueService statistiqueService)
        {
            _statistiqueService = statistiqueService;
        }
        public async Task<BaseResponseDto> Handle(GetCountOrderByProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _statistiqueService.GetCountOrderFollowProCategory();
            return new BaseResponseDto(true, "Lấy thành công", (int)HttpStatusCode.OK, result);
        }
    }
}
