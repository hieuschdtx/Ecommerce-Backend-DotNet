namespace shopecommerce.Domain.Models
{
    public class SlideDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string? image { get; set; }
        public string? url { get; set; }
        public bool status { get; set; }
        public string created_by { get; set; }
        public DateTime created_at { get; set; }
        public string? modified_by { get; set; }
        public DateTime? modified_at { get; set; }
        public long display_order { get; set; }
    }
}
