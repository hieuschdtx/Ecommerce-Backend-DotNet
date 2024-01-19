using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace shopecommerce.API.OptionsSetup
{
    public class TokenVerificationMiddleware
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly RequestDelegate _next;

        public TokenVerificationMiddleware() { }
        public TokenVerificationMiddleware(IJwtProvider jwtProvider, RequestDelegate next)
        {
            _jwtProvider = jwtProvider;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var tokenValue = context.Request.Headers["Authorization"];

            if(string.IsNullOrEmpty(tokenValue))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new BaseResponseDto(false, UserMessages.unauthorized), default);
                return;
            }
            AuthenticationHeaderValue authHeader = AuthenticationHeaderValue.Parse(tokenValue);

            if(!authHeader.Scheme.Equals("Bearer", StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new BaseResponseDto(false, UserMessages.unauthorized), default);
                return;
            }

            var token = authHeader.Parameter;
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            //Kiểm tra sau khi đọc có null hay không
            if(jwtToken == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new BaseResponseDto(false, UserMessages.unauthorized), default);
                return;
            }

            //kiểm tra thời gian hết hạn
            if(jwtToken.ValidTo < DateTime.UtcNow)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new BaseResponseDto(false, UserMessages.unauthorized), default);
                return;
            }

            //Kiểm tra thông tin token của người dùng
            if(!await _jwtProvider.VerifyAccessTokenAsync(token))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsJsonAsync(new BaseResponseDto(false, UserMessages.forbidden), default);
                return;
            }

            await _next.Invoke(context);
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<TokenVerificationMiddleware>();
        }
    }
    public class TokenVerificationMiddlewareImplementation : TokenVerificationMiddleware
    {
        public TokenVerificationMiddlewareImplementation(IJwtProvider jwtProvider, RequestDelegate next) : base(jwtProvider, next)
        {
        }
    }
}