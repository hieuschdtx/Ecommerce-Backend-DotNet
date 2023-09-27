using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.RoleCommand;
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
        public async Task<IActionResult> CreateRoleAsync([FromBody] CreateRoleCommand model)
        {
            var resp = await _mediator.Send(model);
            return Ok(resp);
        }
    }
}