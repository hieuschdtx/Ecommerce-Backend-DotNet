using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.ContactCommand.CreateContact;
using shopecommerce.Application.Commands.ContactCommand.DeleteContact;
using shopecommerce.Domain.Consts;

namespace shopecommerce.API.Controllers
{
    [ApiController]
    [Route("v1/contact")]
    public class ContactController : BaseController
    {
        public ContactController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateContactAsync([FromBody] CreateContactCommand command)
        {
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }

        [HttpDelete]
        [Authorize(Policy = RoleConst.Manager)]
        public async Task<IActionResult> DeleteContactAsync([FromQuery] string id)
        {
            var resp = await _mediator.Send(new DeleteContactCommand(id));
            return Ok(resp);
        }
    }
}