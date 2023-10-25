using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.API.OptionsSetup;
using shopecommerce.Application.Commands.UserCommand.CreateUser;
using shopecommerce.Application.Commands.UserCommand.LoginUser;
using shopecommerce.Application.Commands.UserCommand.LogoutUser;
using shopecommerce.Application.Commands.UserCommand.RegisterUser;
using shopecommerce.Application.Commands.UserCommand.UpdateUser;
using shopecommerce.Application.Queries.UserQuery.GetAllUser;
using shopecommerce.Application.Queries.UserQuery.GetUserById;
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

        [HttpPost("create")]
        [Authorize(Policy = RoleConst.Manager)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateUserAsync([FromForm] CreateUserCommand command)
        {
            var resp = await _mediator.Send(command);
            return resp.success ? Ok(resp) : BadRequest(resp);
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
            return resp.success ? Ok(resp) : Unauthorized(resp);
        }

        [HttpPost("logout")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> LogoutUserAsync()
        {
            var resp = await _mediator.Send(new LogoutUserCommand(CurrentUserId, CurrentRefreshToken));
            return Ok(resp);
        }

        [HttpGet("get-all")]
        [Authorize(Policy = RoleConst.Manager)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserAync()
        {
            var resp = await _mediator.Send(new GetUserQuery());
            return Ok(resp);
        }

        [HttpGet]
        [Authorize(Policy = RoleConst.Manager)]
        public async Task<IActionResult> GetUserByIdAsync([FromQuery] string id)
        {
            var resp = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(resp);
        }

        [HttpGet("profile")]
        [Authorize(Policy = RoleConst.Guest)]
        public async Task<IActionResult> GetUserInformation()
        {
            var resp = await _mediator.Send(new GetUserByIdQuery(CurrentUserId));
            return Ok(resp);
        }
    }
}