using Newtonsoft.Json;

namespace shopecommerce.Domain.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object obj)
        {
            if(obj == null)
                return string.Empty;

            return JsonConvert.SerializeObject(obj);
        }

        public static T FromJson<T>(this string json)
        {
            if(string.IsNullOrWhiteSpace(json))
                return default;

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
