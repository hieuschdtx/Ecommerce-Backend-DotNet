namespace shopecommerce.Domain.Entities
{
    public class ProductDetails : BaseEntites
    {
        public ProductDetails()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public new string id { get; set; }
        public string description { get; set; }
        public string detail { get; set; }
        public string avatar { get; set; }
        public string thumnails { get; set; }
        public bool status { get; set; }
        public bool home_flag { get; set; }
        public bool hot_flag { get; set; }
        public int? memory { get; set; }
        public decimal? price { get; set; }
        public long stock { get; set; }
        public long? view_count { get; set; }
        public string product_id { get; set; }
        public string productvariant_id { get; set; }
        public string promotion_id { get; set; }
        public string producttag_id { get; set; }
        #endregion

        #region Generated Relationships 
        public virtual Products product_Products { get; set; }
        public virtual ProductTags producttag_ProductTags { get; set; }
        public virtual ProductVariants productvariant_ProductVariants { get; set; }
        public virtual Promotions promotion_Promotions { get; set; }
        #endregion
    }
}
