namespace shopecommerce.Domain.Models
{
    public class UserDto
    {
        #region Generated Properties
        public string id { get; set; }
        public string full_name { get; set; }
        public string? address { get; set; }
        public string? avatar { get; set; }
        public DateTime? dob { get; set; }
        public string? refresh_token { get; set; }
        public bool? gender { get; set; }
        public string email { get; set; }
        public bool? email_confirmed { get; set; }
        public string phone_number { get; set; }
        public bool? phone_number_confirmed { get; set; }
        public DateTime? lockout_end { get; set; }
        public int access_failed_count { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? modified_at { get; set; }
        public string role_id { get; set; }
        #endregion
    }
}