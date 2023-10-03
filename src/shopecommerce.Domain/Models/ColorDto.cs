namespace shopecommerce.Domain.Models
{
    public class ColorDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string? create_by { get; set; }
        public DateTime create_at { get; set; }
        public string? modified_by { get; set; }
        public DateTime? modified_at { get; set; }
    }
}
