using AutoMapper;
using shopecommerce.Application.Commands.CategoryCommand.CreateCategory;
using shopecommerce.Application.Commands.CategoryCommand.UpdateCategory;
using shopecommerce.Application.Commands.NewsCommand.CreateNews;
using shopecommerce.Application.Commands.NewsCommand.UpdateNews;
using shopecommerce.Application.Commands.OrderCommand.CreateOrder;
using shopecommerce.Application.Commands.OrderCommand.UpdateOrder;
using shopecommerce.Application.Commands.ProductCategoryCommand.CreateProductCategory;
using shopecommerce.Application.Commands.ProductCategoryCommand.UpdateProductCategory;
using shopecommerce.Application.Commands.ProductCommand.CreateProduct;
using shopecommerce.Application.Commands.ProductCommand.UpdateProduct;
using shopecommerce.Application.Commands.PromotionCommand.CreatePromotion;
using shopecommerce.Application.Commands.PromotionCommand.UpdatePromotion;
using shopecommerce.Application.Commands.RoleCommand.CreateRole;
using shopecommerce.Application.Commands.SlideCommand.CreateSlide;
using shopecommerce.Application.Commands.UserCommand.CreateUser;
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

        CreateMap<UserDto, Users>().ReverseMap()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));

        CreateMap<CreateUserCommand, Users>()
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

        //Promotion Mapper
        CreateMap<CreatePromotionCommand, Promotions>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));

        CreateMap<UpdatePromotionCommand, Promotions>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));

        CreateMap<PromotionDto, Promotions>().ReverseMap()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));

        //Product Category mapper
        CreateMap<CreateProductCategoryCommand, ProductCategories>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));

        CreateMap<UpdateProductCategoryCommand, ProductCategories>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));

        CreateMap<ProductCategoryDto, ProductCategories>().ReverseMap()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));

        //Product mapper
        CreateMap<CreateProductCommand, Products>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));
        CreateMap<UpdateProductCommand, Products>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));
        CreateMap<ProductDto, Products>().ReverseMap()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));
        //ProductPrice mapper

        //Slides mapper
        CreateMap<CreateSlideCommand, Slides>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));

        //News mapper
        CreateMap<CreateNewsCommand, News>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));

        CreateMap<UpdateNewsCommand, News>()
        .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));

        CreateMap<NewsDto, News>().ReverseMap()
        .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));

        //Order Mapper
        CreateMap<CreateOrderCommand, Orders>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));
        CreateMap<UpdateOrderCommand, Orders>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));
    }
}