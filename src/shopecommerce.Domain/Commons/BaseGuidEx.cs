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

    public static bool BeValidGuid(string? id)
    {
        if(!string.IsNullOrEmpty(id))
        {
            return IsGuid(id);
        }

        return true;
    }

    public static string GetNewGuid() => Guid.NewGuid().ToString();
}