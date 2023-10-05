using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.PromotionCommand.CreatePromotion;
using shopecommerce.Application.Commands.PromotionCommand.DeletePromotion;
using shopecommerce.Application.Commands.PromotionCommand.UpdatePromotion;
using System.Net;

namespace shopecommerce.API.Controllers
{
    [ApiController]
    [Route("v1/promotion")]
    public class PromotionController : BaseController
    {
        public PromotionController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreatePromotionAsync([FromBody] CreatePromotionCommand command)
        {
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }

        [HttpPut("update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdatePromotionAsync([FromQuery] string id, [FromBody] UpdatePromotionCommand command)
        {
            command.SetId(id);
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeletePromotionAsync([FromQuery] string id)
        {
            var resp = await _mediator.Send(new DeletePromotionCommand(id));
            return Ok(resp);
        }
    }
}
