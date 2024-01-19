using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace shopecommerce.Domain.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetHeaderValue(this HttpContext context, string key)
        {
            if(context.Request.Headers.TryGetValue(key, out StringValues value) == true)
            {
                return value.ToString();
            }

            return string.Empty;
        }

        public static void SetExpires(this HttpContext context, int minutes)
        {
            var headers = context.Response.GetTypedHeaders();
            headers.Expires = DateTime.UtcNow.AddMinutes(minutes);
        }

        public static void SetHeaderValue(this HttpContext context, string key, string value)
        {
            context.Response.Headers.Add(key, value);
        }
    }
}
