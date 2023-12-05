using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.RoleCommand.CreateRole;
using shopecommerce.Application.Commands.RoleCommand.DeleteRole;
using shopecommerce.Application.Commands.RoleCommand.UpdateRole;
using shopecommerce.Application.Queries.RoleQuery.GetAllRole;
using shopecommerce.Application.Queries.RoleQuery.GetRoleById;
using shopecommerce.Domain.Consts;
using System.Net;

namespace shopecommerce.API.Controllers
{
    [ApiController]
    [Route("v1/role")]

    public class RoleController : BaseController
    {
        public RoleController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

        [HttpPost("create")]
        [Authorize(Policy = RoleConst.Manager)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateRoleAsync([FromBody] CreateRoleCommand command)
        {
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }

        [HttpPut("update")]
        [Authorize(Policy = RoleConst.Manager)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateRoleAsync([FromQuery] string role_id, [FromBody] UpdateRoleCommand command)
        {
            command.SetId(role_id);
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }

        [HttpDelete]
        [Authorize(Policy = RoleConst.Manager)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteRoleAsync([FromQuery] string role_id)
        {
            var resp = await _mediator.Send(new DeleteRoleCommand(role_id));
            return Ok(resp);
        }

        [HttpGet]
        [Authorize(Policy = RoleConst.Employee)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRoleByIdAsync([FromQuery] string id)
        {
            var resp = await _mediator.Send(new GetRoleByIdQuery(id));
            return Ok(resp);
        }

        [HttpGet("get-all")]
        [Authorize(Policy = RoleConst.Manager)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllRoleAsync()
        {
            var resp = await _mediator.Send(new GetAllRoleQuery());
            return Ok(resp);
        }
    }
}