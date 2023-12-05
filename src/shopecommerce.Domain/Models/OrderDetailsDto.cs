namespace shopecommerce.Domain.Models
{
    public class OrderDetailsDto
    {
        public string product_id { get; set; }
        public string order_id { get; set; }
        public int quantity { get; set; }
        public decimal total_amount { get; set; }
    }
}
