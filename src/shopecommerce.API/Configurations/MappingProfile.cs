using AutoMapper;
using shopecommerce.Application.Commands.CategoryCommand;
using shopecommerce.Application.Commands.ColorCommand.CreateColor;
using shopecommerce.Application.Commands.ColorCommand.UpdateColor;
using shopecommerce.Application.Commands.PromotionCommand.CreatePromotion;
using shopecommerce.Application.Commands.RoleCommand;
using shopecommerce.Application.Commands.UserCommand.RegisterUser;
using shopecommerce.Application.Commands.UserCommand.UpdateUser;
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
        CreateMap<RegisterUserCommand, Users>().ReverseMap()
            .ForAllMembers(opts
                => opts.Condition((src, dest, srcMember)
                    => srcMember != null));
        CreateMap<UpdateUserCommand, Users>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));

        //Roles mapper
        CreateMap<CreateRoleCommand, Roles>().ReverseMap()
            .ForAllMembers(opts
                => opts.Condition((src, dest, srcMember)
                    => srcMember != null));
        CreateMap<RoleDto, Roles>().ReverseMap()
            .ForAllMembers(opts
                => opts.Condition((src, dest, srcMember)
                    => srcMember != null));

        //Colors mapper
        CreateMap<CreateColorCommand, Colors>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));
        CreateMap<UpdateColorCommand, Colors>()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));
        CreateMap<ColorDto, Colors>().ReverseMap()
            .ForAllMembers(opts
                => opts.Condition((src, dest, srcMember)
                    => srcMember != null));

        //Promotion Mapper
        CreateMap<CreatePromotionCommand, Promotions>()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));

    }
}