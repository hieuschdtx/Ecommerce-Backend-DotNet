using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;
namespace shopecommerce.Application.Commands.NewsCommand.UpdateNews
{
    public class UpdateNewsCommand : CommandBase<BaseResponseDto>
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public IFormFile? image_file { get; set; }
        public string? detail { get; set; }
        public string modified_by { get; set; }
        public string? category_id { get; set; }
    }
}
