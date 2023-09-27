namespace shopecommerce.Domain.Models
{
    public class CategoryDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public string description { get; set; }
        public string create_by { get; set; }
        public DateTime create_at { get; set; }
        public string modified_by { get; set; }
        public DateTime? modified_at { get; set; }
    }
}
