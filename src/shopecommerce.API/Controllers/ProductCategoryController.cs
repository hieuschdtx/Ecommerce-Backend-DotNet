using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.ProductCategoryCommand.CreateProductCategory;
using shopecommerce.Application.Commands.ProductCategoryCommand.UpdateProductCategory;

namespace shopecommerce.API.Controllers
{
    [ApiController]
    [Route("v1/product-category")]
    public class ProductCategoryController : BaseController
    {
        public ProductCategoryController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateProductCategoryAsync([FromBody] CreateProductCategoryCommand command)
        {
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }

        [HttpPut("update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProductCategoryAsync([FromQuery] string id, [FromBody] UpdateProductCategoryCommand command)
        {
            command.SetId(id);
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }
    }
}