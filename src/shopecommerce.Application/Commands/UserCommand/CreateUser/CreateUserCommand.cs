using Microsoft.AspNetCore.Http;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.UserCommand.CreateUser
{
    public class CreateUserCommand : CommandBase<BaseResponseDto>
    {
        public string full_name { get; set; }
        public string address { get; set; }
        public IFormFile? avatar_file { get; set; }
        public string? day_of_birth { get; set; }
        public bool gender { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone_number { get; set; }
        public string role_id { get; set; }
    }
}
