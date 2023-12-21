using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Queries.StatistiqueQuery.CountOrderFullMonthOfYear;
using shopecommerce.Application.Queries.StatistiqueQuery.GetCountOrderByProductCategory;
using shopecommerce.Application.Queries.StatistiqueQuery.GetMonthlyRevenue;
using shopecommerce.Application.Queries.StatistiqueQuery.GetTotalAmountRevenue;
using System.Net;

namespace shopecommerce.API.Controllers
{
    [Route("v1/statistique")]
    [ApiController]
    public class StatistiqueController : BaseController
    {
        public StatistiqueController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

        [HttpGet("revenue")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMonthlyRevenue([FromQuery] GetMonthlyRevenueQuery query)
        {
            var resp = await _mediator.Send(query);
            return StatusCode(resp.code, resp);
        }

        [HttpGet("{year}/revenue")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTotalAmountRevenue(int year)
        {
            var resp = await _mediator.Send(new GetTotalAmountRevenueQuery(year));
            return StatusCode(resp.code, resp);
        }

        [HttpGet("order-count-product")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCountProductByProductCategory()
        {
            var resp = await _mediator.Send(new GetCountOrderByProductCategoryQuery());
            return StatusCode(resp.code, resp);
        }

        [HttpGet("{year}/order")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CountOrderMonthOfYear(int year, int month)
        {
            var resp = await _mediator.Send(new CountOrderFullMonthOfYearQuery(year, month));
            return StatusCode(resp.code, resp);
        }
    }
}
