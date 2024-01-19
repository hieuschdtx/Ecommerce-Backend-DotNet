using shopecommerce.Domain.Commons;

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
    public string? address { get; set; }
    public string? avatar { get; set; }
    public DateOnly? dob { get; set; }
    public string? refresh_token { get; set; }
    public bool? gender { get; set; }
    public string email { get; set; }
    public bool? email_confirmed { get; set; }
    public string password { get; set; }
    public string phone_number { get; set; }
    public bool? phone_number_confirmed { get; set; }
    public DateTime? lockout_end { get; set; }
    public int? access_failed_count { get; set; }
    public string? verify_code { get; set; }
    public decimal verify_time_exp { get; set; }
    public DateTime? modified_at { get; set; }
    public DateTime created_at { get; set; }
    public string role_id { get; set; }
    #endregion

    #region Generated Relationships
    public virtual Roles role_Roles { get; set; }
    public virtual ICollection<Orders> user_Orders { get; set; }
    #endregion

    public void SetRoleUser(string role_id)
    {
        this.role_id = role_id;
    }

    public void SetCreatedatUser()
    {
        this.created_at = DateTime.Now;
    }
    public void SetModifiedDateUser()
    {
        this.modified_at = DateTime.Now;
    }

    public void SetPassWordHash(string enteredPassword)
    {
        this.password = PasswordHasher.HassPassword(enteredPassword);
    }

    public void SetLoginFaileCount()
    {
        this.access_failed_count++;
    }

    public void SetRefreshToken(string refreshToken)
    {
        this.refresh_token = refreshToken;
    }

    public void SetLockoutEnd()
    {
        this.lockout_end = DateTime.Now;
    }

    public void SetAvatarFileString(string avatar)
    {
        this.avatar = avatar;
    }

    public void SetVerifyCodeExp(string verifyCode, decimal expTime)
    {
        this.verify_code = verifyCode;
        this.verify_time_exp = expTime;
    }
}