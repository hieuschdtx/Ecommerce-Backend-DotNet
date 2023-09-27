namespace shopecommerce.Domain.Entities
{
    public class PaymentMethods
    {
        public PaymentMethods()
        {
            #region Generated Constructor
            payment_method_Orders = new HashSet<Orders>();
            #endregion
        }

        #region Generated Properties
        public string id { get; set; }
        public string name { get; set; }
        #endregion

        #region Generated Relationships
        public virtual ICollection<Orders> payment_method_Orders { get; set; }
        #endregion
    }
}
