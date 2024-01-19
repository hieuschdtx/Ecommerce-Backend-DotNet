namespace shopecommerce.Domain.Models
{
    public class OrderDto
    {
        public string id { get; set; }
        public string customer_name { get; set; }
        public string customer_address { get; set; }
        public string customer_email { get; set; }
        public string customer_phone { get; set; }
        public string? note { get; set; }
        public bool request_invoice { get; set; }
        public DateTime created_at { get; set; }
        public decimal bill_invoice { get; set; }
        public string? user_id { get; set; }
        public int status { get; set; }
        public bool payment_status { get; set; }
        public int payment_methods_id { get; set; }
        public DateTime delivery_date { get; set; }
        public string code { get; set; }
        public bool is_vat { get; set; }
        public string? user_name { get; set; }
        public string? user_email { get; set; }
        public string? user_phone { get; set; }
        public string? user_avatar { get; set; }

    }

    public class OrderDetailDto
    {
        public string id { get; set; }
        public string product_name { get; set; }
        public string? product_avatar { get; set; }
        public string pc_name { get; set; }
        public string product_id { get; set; }
        public string order_id { get; set; }
        public int quantity { get; set; }
        public decimal total_amount { get; set; }
    }
}
