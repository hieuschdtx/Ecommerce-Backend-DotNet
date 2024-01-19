namespace shopecommerce.Domain.Models;

public class PromotionDto
{
    public string id { get; set; }
    public string name { get; set; }
    public int discount { get; set; }
    public DateTime from_day { get; set; }
    public DateTime to_day { get; set; }
    public bool status { get; set; }
    public string? created_by { get; set; }
    public DateTime created_at { get; set; }
    public string? modified_by { get; set; }
    public DateTime? modified_at { get; set; }
}