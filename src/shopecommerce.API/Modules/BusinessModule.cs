using Autofac;
using Microsoft.EntityFrameworkCore;
using shopecommerce.Application.Services.CategoryService;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Extensions;
using shopecommerce.Infrastructure.Authentications;
using shopecommerce.Infrastructure.Configurations;
using shopecommerce.Infrastructure.Data;
using shopecommerce.Infrastructure.Repositories;
using System.Reflection;

namespace shopecommerce.API.Modules;

internal class BusinessModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType(typeof(SqlConnectionFactory))
            .As(typeof(ISqlConnectionFactory)).InstancePerLifetimeScope();

        builder.RegisterType<EcommerceContext>()
            .As<DbContext>().InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(typeof(CategoryRepository).GetTypeInfo().Assembly)
          .AsClosedTypesOf(typeof(IGenericRepository<>))
          .FindConstructorsWith(new AllConstructorFinder())
          .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(typeof(CategoryService).Assembly).
            Where(s => s.Name.EndsWith("Service")).AsImplementedInterfaces().
            InstancePerRequest().InstancePerLifetimeScope();

        builder.RegisterType<HttpContextAccessor>()
            .As<IHttpContextAccessor>().SingleInstance();

        //builder.RegisterType<JwtProvider>()
        //    .As<IJwtProvider>().SingleInstance();

        //Application Service Provider
        //builder.RegisterType(typeof(JwtProvider))
        //    .As(typeof(IJwtProvider)).InstancePerLifetimeScope();

        builder.RegisterType<JwtProvider>().As<IJwtProvider>();
        //builder.RegisterType<JwtValidation>().AsSelf();
        builder.RegisterInstance(new JwtOptions()).SingleInstance(); // Thay thế bằng cách đăng ký từ configuration
        //builder.RegisterInstance(new HttpContextAccessor().HttpContext).As<HttpContext>();
        builder.RegisterInstance(new AppSetting()).SingleInstance(); // Thay thế bằng cách đăng ký từ configuration

        builder.RegisterType(typeof(JwtOptions))
            .AsSelf().SingleInstance();

        builder.RegisterType(typeof(HttpContextExtensionWrapper))
            .As(typeof(IHttpContextExtensionWrapper)).InstancePerLifetimeScope();
    }
}