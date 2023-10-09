using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.API.OptionsSetup
{
    public class AppAuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
    {
        private readonly AuthorizationMiddlewareResultHandler DefaultHandler = new();
        public async Task HandleAsync(RequestDelegate next, HttpContext httpContext, AuthorizationPolicy authorizationPolicy, PolicyAuthorizationResult policyAuthorizationResult)
        {
            if (policyAuthorizationResult.Forbidden == true)
            {
                httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                await httpContext.Response.WriteAsJsonAsync(new BaseResponseDto(false, UserMessages.forbidden), default);
                return;
            }

            if (policyAuthorizationResult.Succeeded == false && httpContext.User.Identity.IsAuthenticated == false)
            {
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await httpContext.Response.WriteAsJsonAsync(new BaseResponseDto(false, UserMessages.unauthorized), default);
                return;
            }

            await DefaultHandler.HandleAsync(next, httpContext, authorizationPolicy, policyAuthorizationResult);
        }
    }
}