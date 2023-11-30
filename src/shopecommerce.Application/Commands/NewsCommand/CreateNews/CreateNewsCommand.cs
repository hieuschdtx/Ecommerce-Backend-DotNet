using Microsoft.AspNetCore.Http;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace shopecommerce.Application.Commands.NewsCommand.CreateNews
{
    public class CreateNewsCommand : CommandBase<BaseResponseDto>
    {
        public string name { get; set; }
        public string? description { get; set; }
        public IFormFile? image_file { get; set; }
        public string? detail { get; set; }
        public string created_by { get; set; }
        public string category_id { get; set; }
    }
}
