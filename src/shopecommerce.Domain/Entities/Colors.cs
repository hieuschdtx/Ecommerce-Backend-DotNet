namespace shopecommerce.Domain.Entities
{
    public class Colors : BaseEntites
    {
        public Colors()
        {
            #region Generated Constructor
            color_ProductColors = new HashSet<ProductColors>();
            #endregion
        }

        #region Generated Properties
        public new string id { get; set; }
        public string name { get; set; }
        public string code { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<ProductColors> color_ProductColors { get; set; }
        #endregion
    }
}
