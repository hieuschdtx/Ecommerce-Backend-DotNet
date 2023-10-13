namespace shopecommerce.Domain.Models
{
    public class ProductPriceDto
    {
        public string id { get; set; }
        public decimal weight { get; set; }
        public decimal price { get; set; }
        public decimal? price_sale { get; set; }
        public string product_id { get; set; }
    }
}