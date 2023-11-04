using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Behaviors;
using shopecommerce.Application.Commands.PromotionCommand.CreatePromotion;
using shopecommerce.Application.Commands.PromotionCommand.DeletePromotion;
using shopecommerce.Application.Commands.PromotionCommand.UpdatePromotion;
using shopecommerce.Application.Queries.PromotionQuery.GetAllPromotion;
using shopecommerce.Application.Queries.PromotionQuery.GetPromotionById;
using shopecommerce.Domain.Consts;
using System.Net;

namespace shopecommerce.API.Controllers
{
    [ApiController]
    [Route("v1/promotion")]
    [Authorize(Policy = RoleConst.Employee)]
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
            return StatusCode(resp.code, new { resp.success, resp.message, resp.data });
        }

        [HttpPut("update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdatePromotionAsync([FromQuery] string id, [FromBody] UpdatePromotionCommand command)
        {
            command.SetId(id);
            var resp = await _mediator.Send(command);
            if(resp.success)
                await _mediator.Publish(new DataChangeNotification());

            return StatusCode(resp.code, new { resp.success, resp.message, resp.data });
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeletePromotionAsync([FromQuery] string id)
        {
            var resp = await _mediator.Send(new DeletePromotionCommand(id));
            if(resp.success)
                await _mediator.Publish(new DataChangeNotification());

            return StatusCode(resp.code, new { resp.success, resp.message, resp.data });
        }

        [HttpGet("get-all")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllPromotionAsync()
        {
            var resp = await _mediator.Send(new GetAllPromotionQuery());
            return Ok(resp);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPromotionById([FromQuery] string id)
        {
            var resp = await _mediator.Send(new GetPromotionByIdQuery(id));
            return Ok(resp);
        }
    }
}
