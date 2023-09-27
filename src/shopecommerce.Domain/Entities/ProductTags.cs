namespace shopecommerce.Domain.Entities
{
    public class ProductTags : BaseEntites
    {
        public ProductTags()
        {
            #region Generated Constructor
            producttag_ProductDetails = new HashSet<ProductDetails>();
            #endregion
        }

        #region Generated Properties
        public new string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        #endregion

        #region Generated Relationships
        public virtual ICollection<ProductDetails> producttag_ProductDetails { get; set; }
        #endregion
    }
}
