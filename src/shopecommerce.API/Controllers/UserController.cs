﻿using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Application.Commands.UserCommand.RegisterUser;
using shopecommerce.Domain.Models;

namespace shopecommerce.API.Controllers
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterUserAsync([FromBody] CreateUserCommand request)
        {
            var resp = await _mediator.Send(request);
            return Ok(resp);
        }
    }
}