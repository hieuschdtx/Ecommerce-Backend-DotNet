using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.ProductCommand.CreatePrice;
using shopecommerce.Application.Commands.ProductCommand.CreateProduct;
using shopecommerce.Application.Commands.ProductCommand.UpdatePrice;
using shopecommerce.Application.Commands.ProductCommand.UpdateProduct;
using shopecommerce.Domain.Consts;

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
            return Ok(resp);
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
    }
}