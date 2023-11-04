using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.API.OptionsSetup;
using shopecommerce.Application.Commands.CategoryCommand.CreateCategory;
using shopecommerce.Application.Commands.CategoryCommand.DeleteCategory;
using shopecommerce.Application.Commands.CategoryCommand.UpdateCategory;
using shopecommerce.Application.Queries.CategoryQuery.GetAllCategory;
using shopecommerce.Application.Queries.CategoryQuery.GetCategoryById;
using shopecommerce.Application.Queries.CategoryQuery.GetCategoryFilter;
using shopecommerce.Application.Queries.CategoryQuery.GetCategoryPaging;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Consts;
using System.Net;

namespace shopecommerce.API.Controllers;
[ApiController]
[Route("v1/category")]
public class CategoryController : BaseController
{
    public CategoryController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
    {
    }

    [HttpPost("create")]
    [Authorize(Policy = RoleConst.Employee)]
    [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryCommand command)
    {
        var resp = await _mediator.Send(command);
        return StatusCode(resp.code, new { resp.success, resp.message, resp.data });
    }

    [HttpPut("update")]
    [Authorize(Policy = RoleConst.Employee)]
    [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateCategoryAsync([FromQuery] string id, [FromBody] UpdateCategoryCommand command)
    {
        command.SetId(id);
        var resp = await _mediator.Send(command);
        return StatusCode(resp.code, new { resp.success, resp.message, resp.data });
    }

    [HttpDelete("delete")]
    [Authorize(Policy = RoleConst.Employee)]
    [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteCategoryAsync([FromQuery] string id)
    {
        var resp = await _mediator.Send(new DeleteCategoryCommand(id));
        return StatusCode(resp.code, new { resp.success, resp.message, resp.data });
    }

    [HttpGet("get-all")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllCategoryAsync()
    {
        var resp = await _mediator.Send(new GetAllCategoryQuery());
        return Ok(resp);
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        var resp = await _mediator.Send(new GetCategoryByIdQuery { category_id = id });
        return Ok(resp);
    }

    [HttpGet("get-page")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategoryPageAsync([FromQuery] QueryStringParameters request)
    {
        var resp = await _mediator.Send(new GetCategoryPagingQuery(request));
        return Ok(resp);
    }

    [HttpGet("search")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategoryFilteringAsync([FromQuery] string searchTerm, [FromQuery] QueryStringParameters parameters)
    {
        var resp = await _mediator.Send(new GetCategoryFilterQuery(searchTerm, parameters));
        return Ok(resp);
    }
}