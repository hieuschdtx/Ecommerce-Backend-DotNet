namespace shopecommerce.Domain.Entities;

public abstract class BaseEntites
{
    public string? created_by { get; set; }
    public DateTime created_at { get; set; }
    public string? modified_by { get; set; }
    public DateTime? modified_at { get; set; }

    private string _id;

    public virtual string id
    {
        get => _id;
        protected set => _id = value;
    }
    public void UpdateModifiedTime() => modified_at = DateTime.Now;
    public void CreateTime() => created_at = DateTime.Now;
    public DateTime SetDateTimeWithoutTimeZone(DateTime dateTime) => DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
    public static DateOnly ParsedDob(string date) => DateOnly.Parse(date);
}