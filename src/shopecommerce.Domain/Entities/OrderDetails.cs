namespace shopecommerce.Domain.Entities
{
    public class OrderDetails
    {
        public OrderDetails()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public string id { get; set; }
        public string product_id { get; set; }
        public string order_id { get; set; }
        public int quantity { get; set; }
        public decimal total_amount { get; set; }
        #endregion

        #region Generated Relationships
        public virtual Orders order_Orders { get; set; }
        public virtual Products product_Products { get; set; }
        #endregion
    }
}
