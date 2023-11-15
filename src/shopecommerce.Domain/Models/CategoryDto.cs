namespace shopecommerce.Domain.Models
{
    public class CategoryDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public string description { get; set; }
        public string created_by { get; set; }
        public DateTime created_at { get; set; }
        public string modified_by { get; set; }
        public int display_order { get; set; }
        public DateTime? modified_at { get; set; }
    }
}
