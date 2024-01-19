using Newtonsoft.Json;
using Npgsql;
using shopecommerce.Domain.Exceptions;
using System.Net;

namespace shopecommerce.API.OptionsSetup
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var message = exception.Message;
            var code = string.Empty;

            if(exception is InvalidCommandException invalidCommandException)
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = invalidCommandException.Message;
                code = invalidCommandException.code;
            }
            else if(exception.InnerException is PostgresException postgresException && postgresException.SqlState == "23503")
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = "Bản ghi chính không thể bị xóa vì có bản ghi phụ đang tham chiếu đến nó.";
                code = postgresException.ErrorCode.ToString();
            }

            var response = new { code, message };
            var payload = JsonConvert.SerializeObject(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(payload);

        }
    }
}