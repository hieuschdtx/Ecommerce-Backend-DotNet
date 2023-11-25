using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.API.OptionsSetup;
using shopecommerce.Application.Commands.ProductCategoryCommand.CreateProductCategory;
using shopecommerce.Application.Commands.ProductCategoryCommand.DeleteProductCategory;
using shopecommerce.Application.Commands.ProductCategoryCommand.UpdateProductCategory;
using shopecommerce.Application.Queries.ProductCategoryQuery.GetAllProductCategory;
using shopecommerce.Application.Queries.ProductCategoryQuery.GetProductCategoriesByCategoryId;
using shopecommerce.Application.Queries.ProductCategoryQuery.GetProductCategoryById;
using shopecommerce.Domain.Consts;
using System.Net;

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
        [Authorize(Policy = RoleConst.Employee)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateProductCategoryAsync([FromBody] CreateProductCategoryCommand command)
        {
            var resp = await _mediator.Send(command);
            return StatusCode(resp.code, new { resp.success, resp.message, resp.data });
        }

        [HttpPut("update")]
        [Authorize(Policy = RoleConst.Employee)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProductCategoryAsync([FromQuery] string id, [FromBody] UpdateProductCategoryCommand command)
        {
            command.SetId(id);
            var resp = await _mediator.Send(command);
            return StatusCode(resp.code, new { resp.success, resp.message, resp.data });
        }

        [HttpDelete]
        [Authorize(Policy = RoleConst.Employee)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductCategoryAsync([FromQuery] string id)
        {
            var resp = await _mediator.Send(new DeleteProductCategoryCommand(id));
            return StatusCode(resp.code, new { resp.success, resp.message, resp.data });
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

        [HttpGet("category")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductCategoryByCategoryIdAsync([FromQuery] string id)
        {
            var resp = await _mediator.Send(new GetProductCategoriesByCategoryIdQuery(id));
            return Ok(resp);
        }
    }
}