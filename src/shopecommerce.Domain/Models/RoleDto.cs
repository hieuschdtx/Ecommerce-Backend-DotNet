namespace shopecommerce.Domain.Models
{
    public class RoleDto
    {
        public string id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string normalize_name { get; set; }
        public string concurrency_stamp { get; set; }
    }
}
