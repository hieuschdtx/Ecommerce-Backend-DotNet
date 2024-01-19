using Microsoft.AspNetCore.Http;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.SlideCommand.UpdateSlide
{
    public class UpdateSlideCommand : CommandBase<BaseResponseDto>
    {
        public string? name { get; set; }
        public IFormFile? banner_image { get; set; }
        public string url { get; set; }
        public bool status { get; set; }
        public string modified_by { get; set; }
    }
}
