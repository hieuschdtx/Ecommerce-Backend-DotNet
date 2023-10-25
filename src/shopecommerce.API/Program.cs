using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using shopecommerce.API.Configurations;
using shopecommerce.API.Modules;
using shopecommerce.API.OptionsSetup;
using shopecommerce.Application.Behaviors;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Consts;
using shopecommerce.Infrastructure.Authentications;
using shopecommerce.Infrastructure.Configurations;
using shopecommerce.Infrastructure.Data;
using System.Data;
using System.Reflection;

namespace shopecommerce.API;

internal class Program
{
    private static void Main(string[ ] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var setting = new AppSetting();
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHttpContextAccessor();

        //Register services
        builder.Services.AddValidatorsFromAssembly(typeof(Program)
           .Assembly, includeInternalTypes: true);

        builder.Services.AddMediatR(cfg =>
           cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        builder.Services.AddScoped<IJwtProvider, JwtProvider>();

        builder.Services.AddScoped<TokenVerificationMiddleware, TokenVerificationMiddlewareImplementation>();

        builder.Services.AddScoped<JwtValidation, JwtValidationImplementation>();

        builder.Services.AddAutofac();
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
           .ConfigureContainer<ContainerBuilder>(options =>
           {
               options.RegisterModule(new BusinessModule());
               options.RegisterModule(new MediatRModule());
           });

        //Connection Db
        builder.Services.AddDbContext<EcommerceContext>(option =>
           option.UseNpgsql(connectionString));

        builder.Services.AddTransient(provider =>
           provider.GetRequiredService<IDbConnection>().BeginTransaction());

        builder.Services.AddTransient<IDbConnection>(_ =>
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            return connection;
        });

        //Jwt Authentication
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = setting.jwtBearerSetting.Name;
            options.DefaultChallengeScheme = setting.jwtBearerSetting.Name;
        })
        .AddJwtBearer()
        .AddCookie(setting.cookieSettings.Name, options =>
        {
            options.SlidingExpiration = true;
            options.Cookie.Name = setting.cookieSettings.Name;
            options.Cookie.HttpOnly = setting.cookieSettings.HttpOnly;
            options.Cookie.Domain = setting.cookieSettings.Domain;
            // options.Cookie.SameSite = setting.cookieSettings.SameSite == "Lax" ? SameSiteMode.Lax : SameSiteMode.None;
            options.Cookie.SameSite = SameSiteMode.None;
            options.Cookie.SecurePolicy = setting.cookieSettings.SecurePolicy ? CookieSecurePolicy.Always : CookieSecurePolicy.None;
        })
        .Services.AddAuthorization(options =>
        {
            var builder = new AuthorizationPolicyBuilder(
                setting.jwtBearerSetting.Name,
                setting.cookieSettings.Name
            );
            builder = builder.RequireAuthenticatedUser();
            options.DefaultPolicy = builder.Build();

            options.AddPolicy(RoleConst.Guest, policy =>
            {
                policy.RequireRole(RoleConst.Manager, RoleConst.Administrator, RoleConst.Guest)
                    .AddAuthenticationSchemes(setting.jwtBearerSetting.Name, setting.cookieSettings.Name);
            });
            options.AddPolicy(RoleConst.Employee, policy =>
           {
               policy.RequireRole(RoleConst.Manager, RoleConst.Administrator, RoleConst.Employee)
                   .AddAuthenticationSchemes(setting.jwtBearerSetting.Name, setting.cookieSettings.Name);
           });
            options.AddPolicy(RoleConst.Manager, policy =>
            {
                policy.RequireRole(RoleConst.Manager, RoleConst.Administrator)
                    .AddAuthenticationSchemes(setting.jwtBearerSetting.Name, setting.cookieSettings.Name);
            });
            options.AddPolicy(RoleConst.Administrator, policy =>
            {
                policy.RequireRole(RoleConst.Administrator)
                    .AddAuthenticationSchemes(setting.jwtBearerSetting.Name, setting.cookieSettings.Name);
            });
        });
        builder.Services.ConfigureOptions<JwtOptionsSetup>();
        builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

        builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, AppAuthorizationMiddlewareResultHandler>();
        // Add cors
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder
                .WithOrigins("http://localhost:3030/")
                .SetIsOriginAllowed(host => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if(app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseAuthentication();

        app.UseAuthorization();

        // app.UseMiddleware<AppAuthorizationMiddlewareResultHandler>();
        //app.UseMiddleware<TokenVerificationMiddleware>();

        app.MapControllers();
        app.UseCors("AllowAllOrigins");

        app.Run();
    }
}