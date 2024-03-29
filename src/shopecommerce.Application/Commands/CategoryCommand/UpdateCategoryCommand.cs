﻿using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.CategoryCommand
{
    public class UpdateCategoryCommand : CommandBase<BaseResponseDto>
    {
        public new string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string modified_by { get; set; }
    }
}
