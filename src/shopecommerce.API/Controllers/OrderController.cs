using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Behaviors;
using shopecommerce.Application.Commands.OrderCommand.CreateOrder;
using shopecommerce.Application.Commands.OrderCommand.DeleteOrder;
using shopecommerce.Application.Commands.OrderCommand.UpdateOrder;
using shopecommerce.Application.Queries.OrderQuery.FilterOrderDetail;
using shopecommerce.Application.Queries.OrderQuery.GetAllOrder;
using shopecommerce.Application.Queries.OrderQuery.GetOrderById;
using shopecommerce.Domain.Consts;
using System.Net;

namespace shopecommerce.API.Controllers
{
    [Route("v1/order")]
    [ApiController]
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            command.SetUserId(CurrentUserId);
            var resp = await _mediator.Send(command);
            return StatusCode(resp.code, new { resp.success, resp.message });
        }

        [HttpGet("get-all")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllOrder()
        {
            var resp = await _mediator.Send(new GetAllOrderQuery());
            return Ok(resp);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrderById([FromQuery] string id)
        {
            var resp = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(resp);
        }

        [HttpGet("{id}/detail")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> FilterOrderDetails(string id)
        {
            var resp = await _mediator.Send(new FilterOrderDetailQuery(id));
            return Ok(resp);
        }

        [HttpPut("{id}/update")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateOrder(string id, [FromBody] UpdateOrderCommand command)
        {
            command.SetId(id);
            var resp = await _mediator.Send(command);
            if(resp.success)
            {
                await _mediator.Publish(new DataChangeNotification());
            }
            return Ok(resp);
        }
        [HttpDelete("{id}/delete")]
        [Authorize(Policy = RoleConst.Manager)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            var resp = await _mediator.Send(new DeleteOrderCommand(id));

            if(resp.success)
            {
                await _mediator.Publish(new DataChangeNotification());
            }
            return Ok(resp);
        }
    }
}
