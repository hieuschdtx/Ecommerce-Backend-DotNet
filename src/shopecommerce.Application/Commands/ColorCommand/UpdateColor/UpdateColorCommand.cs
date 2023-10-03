using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ColorCommand.UpdateColor
{
    public class UpdateColorCommand : CommandBase<BaseResponseDto>
    {
        public string? name { get; set; }
        public string? code { get; set; }
        public string? modified_by { get; set; }
    }
}
