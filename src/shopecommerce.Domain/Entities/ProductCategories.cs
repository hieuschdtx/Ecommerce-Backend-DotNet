using shopecommerce.Domain.Commons;

namespace shopecommerce.Domain.Entities
{
    public class ProductCategories : BaseEntites
    {
        public ProductCategories()
        {
            #region Generated Constructor
            product_category_Products = new HashSet<Products>();
            #endregion
        }

        #region Generated Properties
        public new string id { get; set; }
        private string _name;
        public string name
        {
            get => _name;
            set
            {
                _name = value;
                alias = HandleCharacter.ConvertAlias(value);
            }
        }
        public string? description { get; set; }
        public string alias { get; set; }
        public string category_id { get; set; }
        public string promotion_id { get; set; }
        public int display_order { get; set; }
        #endregion

        #region Generated Relationships
        public virtual Categories category_Categories { get; set; }
        public virtual ICollection<Products> product_category_Products { get; set; }
        public virtual Promotions promotion_Promotions { get; set; }
        #endregion
    }
}
