using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ContactCommand.CreateContact
{
    public class CreateContactCommand : CommandBase<BaseResponseDto>
    {
        public string name { get; set; }
        public string email { get; set; }
        public string message { get; set; }
    }
}