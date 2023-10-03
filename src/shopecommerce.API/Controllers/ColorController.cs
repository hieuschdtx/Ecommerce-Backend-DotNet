using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.ColorCommand.CreateColor;
using shopecommerce.Application.Commands.ColorCommand.UpdateColor;
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

        [HttpPost("update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateColorAsync([FromQuery] string id, [FromBody] UpdateColorCommand command)
        {
            command.SetId(id);
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }
    }
}
