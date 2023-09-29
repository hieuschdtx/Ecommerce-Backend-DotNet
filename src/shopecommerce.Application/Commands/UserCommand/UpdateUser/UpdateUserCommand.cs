using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.UserCommand.UpdateUser
{
    public class UpdateUserCommand : CommandBase<BaseResponseDto>
    {
        public string? full_name { get; set; }
        public string? address { get; set; }
        public string? avatar { get; set; }
        public DateOnly? dob { get; set; }
        public bool? gender { get; set; }
    }
}
