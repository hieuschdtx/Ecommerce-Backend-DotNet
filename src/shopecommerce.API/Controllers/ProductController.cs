using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.API.OptionsSetup;
using shopecommerce.Application.Behaviors;
using shopecommerce.Application.Commands.ProductCommand.AddImageProduct;
using shopecommerce.Application.Commands.ProductCommand.CreatePrice;
using shopecommerce.Application.Commands.ProductCommand.CreateProduct;
using shopecommerce.Application.Commands.ProductCommand.DeleteImageProduct;
using shopecommerce.Application.Commands.ProductCommand.DeleteProduct;
using shopecommerce.Application.Commands.ProductCommand.UpdatePrice;
using shopecommerce.Application.Commands.ProductCommand.UpdateProduct;
using shopecommerce.Application.Queries.ProductQuery.GetAllProduct;
using shopecommerce.Application.Queries.ProductQuery.GetAllProductPrice;
using shopecommerce.Application.Queries.ProductQuery.GetPriceByProductId;
using shopecommerce.Application.Queries.ProductQuery.GetProductById;
using shopecommerce.Application.Queries.ProductQuery.GetProductByProductCategoryId;
using shopecommerce.Application.Queries.ProductQuery.GetProductPaging;
using shopecommerce.Application.Queries.ProductQuery.GetProductsByProductCategory;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Consts;
using System.Net;

namespace shopecommerce.API.Controllers
{
    [ApiController]
    [Route("v1/product")]
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

        [HttpPost("create")]
        [Authorize(Policy = RoleConst.Employee)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateProductAsync([FromForm] CreateProductCommand command)
        {
            var resp = await _mediator.Send(command);
            if(resp.success)
                await _mediator.Publish(new DataChangeNotification());

            return StatusCode(resp.code, new { resp.success, resp.message });
        }

        [HttpPut("update")]
        [Authorize(Policy = RoleConst.Employee)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProductAsync([FromQuery] string id, [FromForm] UpdateProductCommand command)
        {
            command.SetId(id);
            var resp = await _mediator.Send(command);
            if(resp.success)
                await _mediator.Publish(new DataChangeNotification());

            return StatusCode(resp.code, new { resp.success, resp.message });
        }

        [HttpPost("create-price")]
        [Authorize(Policy = RoleConst.Employee)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateProductPriceAsync([FromQuery] string productId, [FromForm] CreatePriceCommand command)
        {
            command.SetId(productId);
            var resp = await _mediator.Send(command);
            if(resp.success)
                await _mediator.Publish(new DataChangeNotification());

            return StatusCode(resp.code, new { resp.success, resp.message });
        }

        [HttpPut("update-price")]
        [Authorize(Policy = RoleConst.Employee)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProductPriceAsync([FromQuery] string id, [FromForm] UpdateProductPriceCommand command)
        {
            command.SetId(id);
            var resp = await _mediator.Send(command);
            if(resp.success)
                await _mediator.Publish(new DataChangeNotification());

            return StatusCode(resp.code, new { resp.success, resp.message });
        }

        [HttpGet("get-all")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
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
        [Authorize(Policy = RoleConst.Employee)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddImageAsync([FromQuery] string id, [FromForm] AddImageProductCommand command)
        {
            command.SetId(id);
            var resp = await _mediator.Send(command);
            if(resp.success)
                await _mediator.Publish(new DataChangeNotification());

            return StatusCode(resp.code, new { resp.success, resp.message });
        }

        [HttpDelete("delete-image")]
        [Authorize(Policy = RoleConst.Employee)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveImageAsync([FromQuery] string id, [FromForm] DeleteImageProductCommand command)
        {
            command.SetId(id);
            var resp = await _mediator.Send(command);
            if(resp.success)
                await _mediator.Publish(new DataChangeNotification());

            return StatusCode(resp.code, new { resp.success, resp.message });
        }

        [HttpGet("price/listing")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPriceByProductIdAsync([FromQuery] string id)
        {
            var resp = await _mediator.Send(new GetPriceByProductIdQuery(id));
            return Ok(resp);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductByIdAsync([FromQuery] string id)
        {
            var resp = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(resp);
        }

        [HttpGet("product-category")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllByProductCategoryId()
        {
            var resp = await _mediator.Send(new GetProductByProductCategoryIdQuery());
            return Ok(resp);
        }

        [HttpGet("listing/pro-category")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProductsByProductCategory([FromQuery] string id, [FromQuery] QueryStringParameters queryStringParameters)
        {
            var resp = await _mediator.Send(new GetProductsByProductCategoryQuery(id, queryStringParameters));
            return Ok(resp);
        }

        [HttpGet("paging")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllProductPaging([FromQuery] QueryStringParameters request)
        {
            var resp = await _mediator.Send(new GetProductPagingQuery(request));
            return Ok(resp);
        }

        [HttpDelete("{id}/detele")]
        public async Task<IActionResult> DeteleProductById(string id)
        {
            var resp = await _mediator.Send(new DeleteProductCommand(id));
            if(resp.success)
                await _mediator.Publish(new DataChangeNotification());

            return Ok(resp);
        }
    }
}