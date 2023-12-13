using shopecommerce.Domain.Commons;

namespace shopecommerce.Domain.Entities
{
    public class Products : BaseEntites
    {
        public Products()
        {
            #region Generated Constructor
            product_OrderDetails = new HashSet<OrderDetails>();
            product_ProductsPrices = new HashSet<ProductsPrices>();
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
        public string? detail { get; set; }
        public string alias { get; set; }
        public string? avatar { get; set; }
        public string? thumnails { get; set; }
        public bool status { get; set; }
        public bool home_flag { get; set; }
        public bool hot_flag { get; set; }
        public int stock { get; set; }
        public int? view_count { get; set; } = 0;
        public string product_category_id { get; set; }
        public string? promotion_id { get; set; }
        public string? origin { get; set; }
        public string? storage { get; set; }
        #endregion

        #region Generated Relationships
        public virtual ProductCategories product_category_ProductCategories { get; set; }
        public virtual ICollection<OrderDetails> product_OrderDetails { get; set; }
        public virtual ICollection<ProductsPrices> product_ProductsPrices { get; set; }
        public virtual Promotions promotion_Promotions { get; set; }
        #endregion

        public void SetAvatarFileString(string avatar)
        {
            this.avatar = avatar;
        }

        public void SetThumnailFileString(string thumnails)
        {
            this.thumnails = thumnails;
        }
        public void SetPromotionId(string promotionId)
        {
            this.promotion_id = promotionId;
        }

        public void SetStock(int stock)
        {
            this.stock -= stock;
        }
    }
}
