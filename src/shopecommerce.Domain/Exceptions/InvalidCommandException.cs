using System.Net;

namespace shopecommerce.Domain.Exceptions;

public class InvalidCommandException : BaseDomainException
{
   public InvalidCommandException(string code, string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) :
      base(code, message, statusCode)
   {
   }

   public InvalidCommandException(string code, string message, List<InvalidCommandItemDto> items) : base(code, message)
   {
      if (items is { Count: > 1 }) errors = items;
   }

   public List<InvalidCommandItemDto> errors { get; }

   public override dynamic GetMessage()
   {
      return new { code, message = Message, errors };
   }

   public class InvalidCommandItemDto
   {
      public InvalidCommandItemDto(string code, string message)
      {
         this.code = code;
         this.message = message;
      }

      public string code { get; set; }
      public string message { get; set; }
   }
}