namespace shopecommerce.Domain.Entities
{
    public class ProductColors
    {
        public ProductColors()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public string id { get; set; } 
        public string product_id { get; set; } 
        public string color_id { get; set; } 
        public string avatar_color { get; set; } 
        #endregion 
        
        #region Generated Relationships 
        public virtual Colors color_Colors { get; set; } 
        public virtual Products product_Products { get; set; } 
        #endregion 
    }
}
