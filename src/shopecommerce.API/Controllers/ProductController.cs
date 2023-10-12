using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.ProductCommand.CreateProduct;
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
        public async Task<IActionResult> CreateProductAsync([FromForm] CreateProductCommand command)
        {
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }
    }
}