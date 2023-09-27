using shopecommerce.Domain.Commons;

namespace shopecommerce.Domain.Entities
{
    public class Products
    {
        public Products()
        {
            #region Generated Constructor
            product_OrderDetails = new HashSet<OrderDetails>();
            product_ProductColors = new HashSet<ProductColors>();
            product_ProductDetails = new HashSet<ProductDetails>();
            product_ProductVariants = new HashSet<ProductVariants>();
            product_Specifications = new HashSet<Specifications>();
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
        public string product_category_id { get; set; } 
        #endregion 
        
        #region Generated Relationships 
        public virtual ProductCategories product_category_ProductCategories { get; set; } 
        public virtual ICollection<OrderDetails> product_OrderDetails { get; set; } 
        public virtual ICollection<ProductColors> product_ProductColors { get; set; } 
        public virtual ICollection<ProductDetails> product_ProductDetails { get; set; } 
        public virtual ICollection<ProductVariants> product_ProductVariants { get; set; } 
        public virtual ICollection<Specifications> product_Specifications { get; set; } 
        #endregion 
    }
}
