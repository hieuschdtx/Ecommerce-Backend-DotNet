namespace shopecommerce.Domain.Entities
{
    public class Orders
    {
        public Orders()
        {
            #region Generated Constructor
            order_OrderDetails = new HashSet<OrderDetails>();
            #endregion
        }

        #region Generated Properties
        public string id { get; set; }
        public string customer_name { get; set; }
        public string customer_address { get; set; }
        public string customer_email { get; set; }
        public string customer_phone { get; set; }
        public DateTime create_at { get; set; }
        public string payment_status { get; set; }
        public string status { get; set; }
        public decimal bill_invoice { get; set; }
        public string payment_method_id { get; set; }
        public string user_id { get; set; }
        #endregion

        #region Generated Relationships
        public virtual ICollection<OrderDetails> order_OrderDetails { get; set; }
        public virtual PaymentMethods payment_method_PaymentMethods { get; set; }
        public virtual Users user_Users { get; set; }
        #endregion
    }
}
