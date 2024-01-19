namespace shopecommerce.Domain.Models
{
    public class NewsDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public string? description { get; set; }
        public string? detail { get; set; }
        public string created_by { get; set; }
        public DateTime created_at { get; set; }
        public string? modified_by { get; set; }
        public DateTime? modified_at { get; set; }
        public string category_id { get; set; }
        public string? image { get; set; }
    }
}
