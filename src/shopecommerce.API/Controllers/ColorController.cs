using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.ColorCommand.CreateColor;
using System.Net;

namespace shopecommerce.API.Controllers
{
    [ApiController]
    [Route("v1/color")]
    public class ColorController : BaseController
    {
        public ColorController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateColorAsync([FromBody] CreateColorCommand command)
        {
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }
    }
}
