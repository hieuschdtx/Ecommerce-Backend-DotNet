namespace shopecommerce.Domain.Entities
{
    public class Promotions : BaseEntites
    {
        public Promotions()
        {
            #region Generated Constructor
            promotion_ProductCategories = new HashSet<ProductCategories>();
            promotion_Products = new HashSet<Products>();
            #endregion
        }

        #region Generated Properties
        public new string id { get; set; }
        public string name { get; set; }
        public int discount { get; set; }
        public DateTime from_day { get; set; }
        public DateTime to_day { get; set; }
        public bool? status { get; set; }
        #endregion

        #region Generated Relationships
        public virtual ICollection<ProductCategories> promotion_ProductCategories { get; set; }
        public virtual ICollection<Products> promotion_Products { get; set; }
        #endregion
    }
}
