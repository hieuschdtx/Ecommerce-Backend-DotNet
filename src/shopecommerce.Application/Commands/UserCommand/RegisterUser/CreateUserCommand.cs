﻿using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.UserCommand.RegisterUser;

public class CreateUserCommand : CommandBase<BaseResponseDto>
{
    public string full_name { get; set; }
    public string phone_number { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string confirm_password { get; set; }
}