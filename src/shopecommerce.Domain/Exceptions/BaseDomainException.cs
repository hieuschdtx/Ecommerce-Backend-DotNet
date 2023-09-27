using System.Net;
using Newtonsoft.Json;

namespace shopecommerce.Domain.Exceptions;

public class BaseDomainException : Exception
{
   public BaseDomainException(string code, string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) :
      base(message)
   {
      this.code = code;
      status = (int)statusCode;
   }
   
   public string code { get; set; }
   public int status { get; set; }

   public virtual dynamic GetMessage()
   {
      return new { code, message = Message };
   }

   public override string ToString()
   {
      return JsonConvert.SerializeObject(GetMessage(),
         new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
   }
}