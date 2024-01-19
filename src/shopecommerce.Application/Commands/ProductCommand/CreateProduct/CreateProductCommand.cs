using Microsoft.AspNetCore.Http;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ProductCommand.CreateProduct
{
    public class CreateProductCommand : CommandBase<BaseResponseDto>
    {
        public string name { get; set; }
        public string? description { get; set; }
        public string? detail { get; set; }
        public IFormFile? avatar_file { get; set; }
        public IEnumerable<IFormFile>? thumbnails_file { get; set; }
        public decimal price { get; set; }
        public decimal weight { get; set; }
        public bool status { get; set; }
        public bool home_flag { get; set; }
        public bool hot_flag { get; set; }
        public int stock { get; set; }
        public string created_by { get; set; }
        public string product_category_id { get; set; }
        public string? origin { get; set; }
        public string? storage { get; set; }
    }
}