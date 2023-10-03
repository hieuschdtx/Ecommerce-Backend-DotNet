using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ColorCommand.CreateColor
{
    public class CreateColorCommand : CommandBase<BaseResponseDto>
    {
        public string name { get; set; }
        public string? code { get; set; }
        public string? create_by { get; set; }
    }
}
