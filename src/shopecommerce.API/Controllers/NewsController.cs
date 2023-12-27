using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.API.OptionsSetup;
using shopecommerce.Application.Behaviors;
using shopecommerce.Application.Commands.NewsCommand.CreateNews;
using shopecommerce.Application.Commands.NewsCommand.DeleteNews;
using shopecommerce.Application.Commands.NewsCommand.UpdateNews;
using shopecommerce.Application.Queries.NewsQuery.GetAllNews;
using shopecommerce.Application.Queries.NewsQuery.GetAllNewsPaging;
using shopecommerce.Application.Queries.NewsQuery.GetNewsById;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Consts;
using System.Net;

namespace shopecommerce.API.Controllers
{
    [ApiController]
    [Route("v1/news")]
    public class NewsController : BaseController
    {
        public NewsController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

        [HttpPost("create")]
        [Authorize(Policy = RoleConst.Employee)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateNewsAsync([FromForm] CreateNewsCommand command)
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
        public async Task<IActionResult> UpdateNewsAsync([FromQuery] string id, [FromForm] UpdateNewsCommand command)
        {
            command.SetId(id);
            var resp = await _mediator.Send(command);
            if(resp.success)
                await _mediator.Publish(new DataChangeNotification());
            return StatusCode(resp.code, new { resp.success, resp.message });
        }

        [HttpDelete("{id}/delete")]
        [Authorize(Policy = RoleConst.Employee)]
        [MiddlewareFilter(typeof(TokenVerificationMiddleware))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteNewsAsync(string id)
        {
            var resp = await _mediator.Send(new DeleteNewsCommand(id));
            if(resp.success)
                await _mediator.Publish(new DataChangeNotification());
            return StatusCode(resp.code, new { resp.success, resp.message });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var resp = await _mediator.Send(new GetAllNewsQuery());
            return Ok(resp);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPagingAsync([FromQuery] QueryStringParameters request)
        {
            var resp = await _mediator.Send(new GetAllNewsPagingQuery(request));
            return Ok(resp);
        }

        [HttpGet("{id}/detail")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var resp = await _mediator.Send(new GetNewsByIdQuery(id));
            return Ok(resp);
        }
    }
}
