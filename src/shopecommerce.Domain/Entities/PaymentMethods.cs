namespace shopecommerce.Domain.Entities
{
    public class PaymentMethods
    {
        public PaymentMethods()
        {
            #region Generated Constructor
            payment_methods_Orders = new HashSet<Orders>();
            #endregion
        }

        #region Generated Properties
        public string name { get; set; }
        public int id { get; set; }
        #endregion

        #region Generated Relationships
        public virtual ICollection<Orders> payment_methods_Orders { get; set; }

        #endregion
    }
}
