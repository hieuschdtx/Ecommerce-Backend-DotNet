using AutoMapper;
using shopecommerce.Application.Commands.CategoryCommand;
using shopecommerce.Application.Commands.RoleCommand;
using shopecommerce.Application.Commands.UserCommand.RegisterUser;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Models;

namespace shopecommerce.API.Configurations;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        //Categories mapper
        CreateMap<CreateCategoryCommand, Categories>().ReverseMap()
          .ForAllMembers(opts
            => opts.Condition((src, dest, srcMember)
              => srcMember != null));
        CreateMap<UpdateCategoryCommand, Categories>().ReverseMap()
          .ForAllMembers(opts
            => opts.Condition((src, dest, srcMember)
              => srcMember != null));
        CreateMap<CategoryDto, Categories>().ReverseMap()
          .ForAllMembers(opts
            => opts.Condition((src, dest, srcMember)
              => srcMember != null));

        //Users mapper
        CreateMap<CreateUserCommand, Users>().ReverseMap()
            .ForAllMembers(opts
                => opts.Condition((src, dest, srcMember)
                    => srcMember != null));

        //Roles mapper
        CreateMap<CreateRoleCommand, Roles>().ReverseMap()
            .ForAllMembers(opts
                => opts.Condition((src, dest, srcMember)
                    => srcMember != null));
        CreateMap<RoleDto, Roles>().ReverseMap()
            .ForAllMembers(opts
                => opts.Condition((src, dest, srcMember)
                    => srcMember != null));
    }
}