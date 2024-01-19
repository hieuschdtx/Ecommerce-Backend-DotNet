using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.API.OptionsSetup;
using shopecommerce.Application.Behaviors;
using shopecommerce.Application.Commands.SlideCommand.CreateSlide;
using shopecommerce.Application.Queries.SlideQuery.GetAllSlide;
using shopecommerce.Domain.Consts;
using System.Net;

namespace shopecommerce.API.Controllers
{
    [ApiController]
    [Route("v1/slide")]
    public class SlideController : BaseController
    {
        public SlideController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

        [HttpPost("create")]
        [Authorize(Policy = RoleConst.Employee)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateSlideAsync([FromForm] CreateSlideCommand command)
        {
            var resp = await _mediator.Send(command);
            if(resp.success)
                await _mediator.Publish(new DataChangeNotification());
            return StatusCode(resp.code, new { resp.success, resp.message });
        }

        [HttpGet("get-all")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllSlideAsync()
        {
            var resp = await _mediator.Send(new GetAllSlideQuery());
            return Ok(resp);
        }

    }
}
