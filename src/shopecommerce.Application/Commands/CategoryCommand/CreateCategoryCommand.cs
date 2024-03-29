﻿using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.CategoryCommand;

public class CreateCategoryCommand : CommandBase<BaseResponseDto>
{
    public string name { get; set; }
    public string? description { get; set; }
    public string? create_by { get; set; }
}