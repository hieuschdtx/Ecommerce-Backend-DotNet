using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.RoleCommand;
using shopecommerce.Application.Queries.RoleQuery;
using System.Net;

namespace shopecommerce.API.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : BaseController
    {
        public RoleController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateRoleAsync([FromBody] CreateRoleCommand command)
        {
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }

        [HttpPut("update")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> UpdateRoleAsync([FromQuery] string role_id, [FromBody] UpdateRoleCommand command)
        {
            command.SetId(role_id);
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteRoleAsync([FromQuery] string role_id)
        {
            var resp = await _mediator.Send(new DeleteRoleCommand(role_id));
            return Ok(resp);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRoleByIdAsync([FromQuery] string role_id)
        {
            var resp = await _mediator.Send(new GetRoleByIdQuery(role_id));
            return Ok(resp);
        }
    }
}