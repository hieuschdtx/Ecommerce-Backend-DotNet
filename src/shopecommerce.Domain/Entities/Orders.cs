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
        public string code { get; set; }
        public string customer_name { get; set; }
        public string customer_address { get; set; }
        public string customer_email { get; set; }
        public string customer_phone { get; set; }
        public string? note { get; set; }
        public bool request_invoice { get; set; }
        public DateTime delivery_date { get; set; }
        public DateTime created_at { get; set; }
        public decimal bill_invoice { get; set; }
        public bool is_vat { get; set; }
        public string? user_id { get; set; }
        public int status { get; set; }
        public bool payment_status { get; set; } = false;
        public int payment_methods_id { get; set; }

        #endregion

        #region Generated Relationships
        public virtual ICollection<OrderDetails> order_OrderDetails { get; set; }
        public virtual PaymentMethods payment_methods_PaymentMethods { get; set; }
        public virtual Users user_Users { get; set; }
        #endregion

        public void SetCreatedTime()
        {
            this.created_at = DateTime.Now;
        }

        public void setUserId(string userId)
        {
            if(userId == null)
            {
                this.user_id = null;
            }
            this.user_id = userId;
        }
        public void SetDateTimeWithoutTimeZone(DateTime dateTime)
        {
            this.delivery_date = DateTime.SpecifyKind(dateTime.AddHours(7), DateTimeKind.Unspecified);
        }

        public void SetCodeOrder()
        {
            var rd = new Random();
            this.code = "DH" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9);
        }

        public void SetIsVAT(decimal billInvoice)
        {
            this.is_vat = !(billInvoice >= 300000);
        }
    }
}
