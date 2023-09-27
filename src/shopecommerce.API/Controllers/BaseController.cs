using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace shopecommerce.API.Controllers;

public class BaseController : ControllerBase
{
  protected readonly IMediator _mediator;
  protected readonly IAuthorizationService _authorizationService;
  public BaseController( IMediator mediator, IAuthorizationService authorizationService )
  {
    _mediator = mediator;
    _authorizationService = authorizationService;
  }
}