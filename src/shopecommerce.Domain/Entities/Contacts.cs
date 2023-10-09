namespace shopecommerce.Domain.Entities
{
    public class Contacts
    {
        public Contacts(string id, string name, string email, string message)
        {
            #region Generated Constructor
            this.id = id;
            this.name = name;
            this.email = email;
            this.message = message;
            this.created_at = DateTime.Now;
            #endregion
        }

        #region Generated Properties
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string message { get; set; }
        public DateTime created_at { get; set; }
        #endregion

        #region Generated Relationships
        #endregion
    }
}
