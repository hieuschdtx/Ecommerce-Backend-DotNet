using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.CategoryCommand;
using shopecommerce.Application.Queries.CategoryQuery;
using shopecommerce.Domain.Commons;

namespace shopecommerce.API.Controllers;
[ApiController]
[Route("v1/category")]
public class CategoryController : BaseController
{
    public CategoryController( IMediator mediator, IAuthorizationService authorizationService ) : base(mediator, authorizationService)
    {
    }

    [HttpPost]
    [Route("create")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateCategoryAsync( [FromBody] CreateCategoryCommand model )
    {
        var resp = await _mediator.Send(model);
        return Ok(resp);
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateCategoryAsync( [FromBody] UpdateCategoryCommand model )
    {
        var resp = await _mediator.Send(model);
        return Ok(resp);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> DeleteCategoryAsync( [FromQuery] string id )
    {
        var resp = await _mediator.Send(new DeleteCategoryCommand(id));
        return Ok(resp);
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllCategoryAsync()
    {
        var resp = await _mediator.Send(new GetAllCategoryQuery());
        return Ok(resp);
    }
    
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategoryById( string id )
    {
        var resp = await _mediator.Send(new GetCategoryByIdQuery { category_id = id });
        return Ok(resp);
    }

    [HttpGet]
    [Route("get-page")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategoryPageAsync([FromQuery] QueryStringParameters request)
    {
        var resp = await _mediator.Send(new GetCategoryPagingQuery(request));
        return Ok(resp);
    }

    [HttpGet]
    [Route("search")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategoryFilteringAsync([FromQuery] string searchTerm, [FromQuery] QueryStringParameters parameters)
    {
        var resp = await _mediator.Send(new GetCategoryFilterQuery(searchTerm, parameters));
        return Ok(resp);
    }
}