namespace shopecommerce.Domain.Models
{
    public class ProductDto
    {

    }
    public class Image
    {
        public string fileName { get; set; }
    }
    public class Prices
    {
        public decimal weight { get; set; }
        public decimal price { get; set; }
    }

    public class ProductPrices
    {
        public string id { get; set; }
        public decimal weight { get; set; }
        public decimal price { get; set; }
    }
}