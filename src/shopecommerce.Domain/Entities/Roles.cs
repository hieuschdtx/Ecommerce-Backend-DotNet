namespace shopecommerce.Domain.Entities
{
    public class Roles
    {
        public Roles()
        {
            #region Generated Constructor
            role_Users = new HashSet<Users>();
            #endregion
        }

        #region Generated Properties
        public string id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string normalize_name { get; set; }
        public string concurrency_stamp { get; set; }
        #endregion
        
        #region Generated Relationships
        public virtual ICollection<Users> role_Users { get; set; }
        #endregion
    }
}
