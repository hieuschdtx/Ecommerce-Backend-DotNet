using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopecommerce.Domain.Consts;

namespace shopecommerce.API.Controllers;

public class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;
    protected readonly IAuthorizationService _authorizationService;
    public BaseController(IMediator mediator, IAuthorizationService authorizationService)
    {
        _mediator = mediator;
        _authorizationService = authorizationService;
    }

    private string? _currentUserId = null;

    public string CurrentUserId
    {
        get
        {
            if (User.Identity.IsAuthenticated == false) return "00000000-0000-0000-0000-000000000000";
            return _currentUserId ??= User.FindFirstValue(ClaimTypeConst.Id) ?? "0";
        }
    }

    private string? _refreshToken = null;

    public string CurrentRefreshToken
    {
        get
        {
            if (User.Identity.IsAuthenticated == false) return "0";
            return _refreshToken ??= User.FindFirstValue(ClaimTypeConst.RefreshToken) ?? "0";
        }
    }

    private bool? _currentIsEmployee = null;

    public bool IsEmployee
    {
        get
        {
            if (User.Identity.IsAuthenticated == false) return false;
            if (_currentIsEmployee.HasValue) return _currentIsEmployee.Value;
            _currentIsEmployee = User.HasClaim(ClaimTypes.Role, RoleConst.Employee) && (User.IsInRole(RoleConst.Administrator) || User.IsInRole(RoleConst.Manager));
            return _currentIsEmployee.Value;
        }
    }
}