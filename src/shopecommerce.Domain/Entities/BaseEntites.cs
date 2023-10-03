namespace shopecommerce.Domain.Entities;

public abstract class BaseEntites
{
    public string? create_by { get; set; }
    public DateTime create_at { get; set; }
    public string? modified_by { get; set; }
    public DateTime? modified_at { get; set; }

    private string _id;

    public virtual string id
    {
        get => _id;
        protected set => _id = value;
    }
    public void UpdateModifiedTime() => modified_at = DateTime.Now;
    public void CreateTime() => create_at = DateTime.Now;
}