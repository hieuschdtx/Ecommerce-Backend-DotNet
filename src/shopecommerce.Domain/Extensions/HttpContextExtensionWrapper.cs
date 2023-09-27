using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace shopecommerce.Domain.Extensions
{
    public interface IHttpContextExtensionWrapper
    {
        string GetHeaderValue(HttpContext context, string key);

        string GetETag(HttpContext context);

        void SetExpires(HttpContext context, int minutes);
    }
    public class HttpContextExtensionWrapper : IHttpContextExtensionWrapper
    {
        public string GetETag(HttpContext context)
        {
            return context.GetHeaderValue(HeaderNames.ETag);
        }

        public string GetHeaderValue(HttpContext context, string key)
        {
            return context.GetHeaderValue(key);
        }

        public void SetExpires(HttpContext context, int minutes)
        {
            context.SetExpires(minutes);
        }
    }
}
