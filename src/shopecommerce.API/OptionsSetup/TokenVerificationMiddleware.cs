namespace shopecommerce.API.OptionsSetup
{
    public class TokenVerificationMiddleware
    {
        private readonly RequestDelegate _next;
        public TokenVerificationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var endPoint = httpContext.Request.Path.Value;
            if(endPoint.Contains("/login") || endPoint.Contains("/register"))
            {
                await _next(httpContext);
            }

            string authorization = httpContext.Request.Headers["Authorization"];

            if(!string.IsNullOrEmpty(authorization))
            {
                var token = authorization[authorization.IndexOf(" ")..];
                if(token is not null)
                {
                    await _next(httpContext);
                }

                else
                {
                    httpContext.Response.StatusCode = 401;
                    await httpContext.Response.WriteAsync("Token không hợp lệ");
                }
            }
        }
    }
}