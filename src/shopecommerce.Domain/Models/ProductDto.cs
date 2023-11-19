namespace shopecommerce.Domain.Models
{
    public class ProductDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string? description { get; set; }
        public string? detail { get; set; }
        public string alias { get; set; }
        public string? avatar { get; set; }
        public string? thumnails { get; set; }
        public bool status { get; set; }
        public bool home_flag { get; set; }
        public bool hot_flag { get; set; }
        public int stock { get; set; }
        public int? view_count { get; set; }
        public string product_category_id { get; set; }
        public string? promotion_id { get; set; }
        public string? origin { get; set; }
        public string? storage { get; set; }
    }
    public class Image
    {
        public string fileName { get; set; }
    }
    //public class Prices
    //{
    //    public decimal weight { get; set; }
    //    public decimal price { get; set; }
    //}

    public class ProductPrices : ProductDto
    {
        public string price_id { get; set; }
        public decimal weight { get; set; }
        public decimal price { get; set; }
        public decimal price_sale { get; set; }
        public int discount { get; set; }
    }
}