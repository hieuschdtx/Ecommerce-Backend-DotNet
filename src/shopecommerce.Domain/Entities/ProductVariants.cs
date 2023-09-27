using shopecommerce.Domain.Commons;

namespace shopecommerce.Domain.Entities
{
    public class ProductVariants
    {
        public ProductVariants()
        {
            #region Generated Constructor
            productvariant_ProductDetails = new HashSet<ProductDetails>();
            productvariant_Specifications = new HashSet<Specifications>();
            #endregion
        }

        #region Generated Properties
        public string id { get; set; }
        private string _name;
        public string name {
            get => _name;
            set
            {
                _name = value;
                alias = HandleCharacter.ConvertAlias(value);
            }
        }
        public string alias { get; set; }
        public string product_id { get; set; }
        #endregion
        
        #region Generated Relationships
        public virtual Products product_Products { get; set; }
        public virtual ICollection<ProductDetails> productvariant_ProductDetails { get; set; }
        public virtual ICollection<Specifications> productvariant_Specifications { get; set; }
        #endregion
    }
}
