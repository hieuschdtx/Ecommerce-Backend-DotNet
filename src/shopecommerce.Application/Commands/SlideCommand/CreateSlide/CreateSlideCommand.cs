using Microsoft.AspNetCore.Http;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.SlideCommand.CreateSlide
{
    public class CreateSlideCommand : CommandBase<BaseResponseDto>
    {
        public string name { get; set; }
        public IFormFile? banner_image { get; set; }
        public string? url { get; set; }
        public bool status { get; set; }
        public string created_by { get; set; }
    }
}
