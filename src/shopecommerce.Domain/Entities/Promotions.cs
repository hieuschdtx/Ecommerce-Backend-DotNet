namespace shopecommerce.Domain.Entities
{
    public class Promotions : BaseEntites
    {
        public Promotions()
        {
            #region Generated Constructor
            promotion_ProductCategories = new HashSet<ProductCategories>();
            promotion_ProductDetails = new HashSet<ProductDetails>();
            #endregion
        }

        #region Generated Properties
        public new string id { get; set; }
        public string description { get; set; }
        public int discount { get; set; }
        public DateTime from_day { get; set; }
        public DateTime to_day { get; set; }
        #endregion

        #region Generated Relationships
        public virtual ICollection<ProductCategories> promotion_ProductCategories { get; set; }
        public virtual ICollection<ProductDetails> promotion_ProductDetails { get; set; }
        #endregion
    }
}
