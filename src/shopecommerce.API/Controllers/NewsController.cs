using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.API.OptionsSetup;
using shopecommerce.Application.Commands.NewsCommand.CreateNews;
using shopecommerce.Domain.Consts;
using System.Net;

namespace shopecommerce.API.Controllers
{
    [ApiController]
    [Route("v1/news")]
    public class NewsController : BaseController
    {
        public NewsController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }
        [HttpPost("create")]
        [Authorize(Policy = RoleConst.Employee)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateNewsAsync([FromForm] CreateNewsCommand command)
        {
            var resp = await _mediator.Send(command);
            return StatusCode(resp.code, new { resp.success, resp.message });
        }
    }
}
