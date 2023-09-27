namespace shopecommerce.Domain.Commons;

public static class BaseGuidEx
{
    public static bool IsGuid(string value)
    {
        return Guid.TryParse(value, out _);
    }

    public static Guid GetGuid(string value)
    {
        return Guid.Parse(value);
    }
}