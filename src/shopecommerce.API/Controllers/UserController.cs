using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.UserCommand.LoginUser;
using shopecommerce.Application.Commands.UserCommand.LogoutUser;
using shopecommerce.Application.Commands.UserCommand.RegisterUser;
using shopecommerce.Application.Commands.UserCommand.UpdateUser;
using shopecommerce.Application.Queries.UserQuery.GetAllUser;
using shopecommerce.Domain.Consts;
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

        [HttpGet("unauthorized")]
        public IActionResult GetUnAuthenticated()
        {
            return Unauthorized();
        }

        [HttpPost("register")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserCommand request)
        {
            var resp = await _mediator.Send(request);
            return Ok(resp);
        }

        [HttpPut("update")]
        [Authorize(Policy = RoleConst.Manager)]
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

        [HttpPost("logout")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> LogoutUserAsync()
        {
            var resp = await _mediator.Send(new LogoutUserCommand(CurrentUserId, CurrentRefreshToken));
            return Ok(resp);
        }

        [HttpGet]
        [Authorize(Policy = RoleConst.Employee)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserAync()
        {
            var resp = await _mediator.Send(new GetUserQuery());
            return Ok(resp);
        }
    }
}