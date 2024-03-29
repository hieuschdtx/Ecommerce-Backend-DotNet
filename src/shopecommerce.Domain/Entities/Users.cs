namespace shopecommerce.Domain.Entities;

public class Users
{
    public Users()
    {
        #region Generated Constructor
        user_Orders = new HashSet<Orders>();
        #endregion
    }

    #region Generated Properties
    public string id { get; set; }
    public string full_name { get; set; }
    public string address { get; set; }
    public string avatar { get; set; }
    public DateOnly? dob { get; set; }
    public string refresh_token { get; set; }
    public bool? gender { get; set; }
    public DateTime created_at { get; set; }
    public string email { get; set; }
    public bool? email_confirmed { get; set; }
    public string password { get; set; }
    public string security_stamp { get; set; }
    public string concurrency_stamp { get; set; }
    public string phone_number { get; set; }
    public bool? phone_number_confirmed { get; set; }
    public DateTime? lockout_end { get; set; }
    public int? access_failed_count { get; set; }
    public string role_id { get; set; }
    #endregion
        
    #region Generated Relationships
    public virtual Roles role_Roles { get; set; }
    public virtual ICollection<Orders> user_Orders { get; set; }
    #endregion
}