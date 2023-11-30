using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.API.OptionsSetup;
using shopecommerce.Application.Commands.NewsCommand.CreateNews;
using shopecommerce.Application.Commands.NewsCommand.DeleteNews;
using shopecommerce.Application.Commands.NewsCommand.UpdateNews;
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

        [HttpPut("update")]
        [Authorize(Policy = RoleConst.Employee)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateNewsAsync([FromQuery] string id, [FromForm] UpdateNewsCommand command)
        {
            command.SetId(id);
            var resp = await _mediator.Send(command);
            return StatusCode(resp.code, new { resp.success, resp.message });
        }

        [HttpDelete]
        [Authorize(Policy = RoleConst.Employee)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteNewsAsync([FromQuery] string id)
        {
            var resp = await _mediator.Send(new DeleteNewsCommand(id));
            return StatusCode(resp.code, new { resp.success, resp.message });
        }
    }
}
