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
    public BaseResponseDto(bool b, string? s, int c)
    {
        success = b;
        message = s;
        code = c;
    }

    public BaseResponseDto(bool b, string? s, int c, object? d)
    {
        success = b;
        message = s;
        data = d;
        code = c;
    }

    public bool success { get; init; }
    public int code { get; init; }
    public string? message { get; init; }
    public object? data { get; init; }
}