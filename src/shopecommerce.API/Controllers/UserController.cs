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
            return StatusCode(resp.code, new { resp.success, resp.message, resp.data });
        }

        [HttpPost("create")]
        [Authorize(Policy = RoleConst.Manager)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateUserAsync([FromForm] CreateUserCommand command)
        {
            var resp = await _mediator.Send(command);
            return StatusCode(resp.code, new { resp.success, resp.message, resp.data });
        }


        [HttpPut("update")]
        [Authorize(Policy = RoleConst.Manager)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUserAsync([FromQuery] string id, [FromBody] UpdateUserCommand command)
        {
            command.SetId(id);

            var resp = await _mediator.Send(command);
            return StatusCode(resp.code, new { resp.success, resp.message, resp.data });
        }

        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserCommand command)
        {
            var resp = await _mediator.Send(command);
            return StatusCode(resp.code, new { resp.success, resp.message, resp.data });
        }

        [HttpPost("logout")]
        [Authorize]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> LogoutUserAsync()
        {
            var resp = await _mediator.Send(new LogoutUserCommand(CurrentUserId, CurrentRefreshToken));
            return StatusCode(resp.code, new { resp.success, resp.message, resp.data });
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
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        public async Task<IActionResult> GetUserByIdAsync([FromQuery] string id)
        {
            var resp = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(resp);
        }

        [HttpGet("profile")]
        [Authorize(Policy = RoleConst.Guest)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        public async Task<IActionResult> GetUserInformation()
        {
            var resp = await _mediator.Send(new GetUserByIdQuery(CurrentUserId));
            return Ok(resp);
        }
    }
}