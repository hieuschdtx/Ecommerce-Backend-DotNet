using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Behaviors;
using shopecommerce.Application.Commands.ProductCommand.AddImageProduct;
using shopecommerce.Application.Commands.ProductCommand.CreatePrice;
using shopecommerce.Application.Commands.ProductCommand.CreateProduct;
using shopecommerce.Application.Commands.ProductCommand.UpdatePrice;
using shopecommerce.Application.Commands.ProductCommand.UpdateProduct;
using shopecommerce.Application.Queries.ProductQuery.GetAllProduct;
using shopecommerce.Application.Queries.ProductQuery.GetAllProductPrice;
using shopecommerce.Domain.Consts;
using System.Net;

namespace shopecommerce.API.Controllers
{
    [ApiController]
    [Route("v1/product")]
    [Authorize(Policy = RoleConst.Employee)]
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CreateProductAsync([FromForm] CreateProductCommand command)
        {
            var resp = await _mediator.Send(command);
            if(resp.success)
                await _mediator.Publish(new DataChangeNotification());

            return StatusCode(resp.code, new { resp.success, resp.message });
        }

        [HttpPut("update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UpdateProductAsync([FromQuery] string id, [FromForm] UpdateProductCommand command)
        {
            command.SetId(id);
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }

        [HttpPost("create-price")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CreateProductPriceAsync([FromQuery] string productId, [FromBody] CreatePriceCommand command)
        {
            command.SetId(productId);
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }

        [HttpPut("update-price")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UpdateProductPriceAsync([FromQuery] string id, [FromBody] UpdateProductPriceCommand command)
        {
            command.SetId(id);
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }

        [HttpGet("get-all")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAllProductAsync()
        {
            var resp = await _mediator.Send(new GetAllProductQuery());
            return Ok(resp);
        }

        [HttpGet("price")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAllProductPriceAsync()
        {
            var resp = await _mediator.Send(new GetAllProductPriceQuery());
            return Ok(resp);
        }

        [HttpPut("update-image")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> AddImageAsync([FromQuery] string id, [FromForm] AddImageProductCommand command)
        {
            command.SetId(id);
            var resp = await _mediator.Send(command);

            return Ok(resp);
        }
    }
}