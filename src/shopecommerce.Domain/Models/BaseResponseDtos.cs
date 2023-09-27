namespace shopecommerce.Domain.Models;

public class BaseResponseDto
{
   public BaseResponseDto(bool b, string? s)
   {
      success = b;
      message = s;
   }

   public BaseResponseDto(bool b, string? s, object? d)
   {
      success = b;
      message = s;
      data = d;
   }

   public bool success { get; init; }
   public string? message { get; init; }
   public object? data { get; set; }
}