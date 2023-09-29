using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.UserCommand.LoginUser;
using shopecommerce.Application.Commands.UserCommand.RegisterUser;
using shopecommerce.Application.Commands.UserCommand.UpdateUser;
using System.Net;

namespace shopecommerce.API.Controllers
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

        [HttpPost("register")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserCommand request)
        {
            var resp = await _mediator.Send(request);
            return Ok(resp);
        }

        [HttpPut("update")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> UpdateUserAsync([FromQuery] string id, [FromBody] UpdateUserCommand command)
        {
            command.SetId(id);

            var resp = await _mediator.Send(command);
            return Ok(resp);
        }

        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserCommand command)
        {
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }

    }
}