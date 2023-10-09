using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.ProductCategoryCommand.CreateProductCategory;
using shopecommerce.Application.Commands.ProductCategoryCommand.DeleteProductCategory;
using shopecommerce.Application.Commands.ProductCategoryCommand.UpdateProductCategory;
using shopecommerce.Application.Queries.ProductCategoryQuery.GetAllProductCategory;
using shopecommerce.Application.Queries.ProductCategoryQuery.GetProductCategoryById;
using shopecommerce.Domain.Consts;

namespace shopecommerce.API.Controllers
{
    [ApiController]
    [Route("v1/product-category")]
    [Authorize(Policy = RoleConst.Employee)]
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

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteProductCategoryAsync([FromQuery] string id)
        {
            var resp = await _mediator.Send(new DeleteProductCategoryCommand(id));
            return Ok(resp);
        }

        [HttpGet("get-all")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllProductCategoryAsync()
        {
            var resp = await _mediator.Send(new GetAllProductCategoryQuery());
            return Ok(resp);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllProductCategoryAsync([FromQuery] string id)
        {
            var resp = await _mediator.Send(new GetProductCategoryByIdQuery(id));
            return Ok(resp);
        }
    }
}