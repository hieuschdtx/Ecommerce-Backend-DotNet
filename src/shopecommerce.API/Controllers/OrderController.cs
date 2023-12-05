using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.OrderCommand.CreateOrder;
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
    }
}
