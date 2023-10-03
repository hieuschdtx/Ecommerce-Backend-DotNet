using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using shopecommerce.API.Configurations;
using shopecommerce.API.Modules;
using shopecommerce.API.OptionsSetup;
using shopecommerce.Application.Behaviors;
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
        //Identity
        // builder.Services.AddIdentity<Users, Roles>(options =>
        // {
        //    options.Password.RequireLowercase = false;
        //    options.Password.RequireDigit = false;
        //    options.Password.RequiredLength = 8;
        //    options.Password.RequireNonAlphanumeric = true;
        //    options.Password.RequireUppercase = true;
        //    options.Password.RequiredUniqueChars = 1;
        //    //lockout
        //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
        //    options.Lockout.MaxFailedAccessAttempts = 5;
        //    options.User.RequireUniqueEmail = true;
        // }).AddEntityFrameworkStores<EcommerceContext>();

        //Jwt Authentication
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer()
        .AddCookie(setting.Cookie.Name, options =>
        {
            options.SlidingExpiration = true;
            options.Cookie.Name = setting.Cookie.Name;
            options.Cookie.HttpOnly = setting.Cookie.HttpOnly;
            options.Cookie.Domain = setting.Cookie.Domain;
            options.Cookie.SameSite = setting.Cookie.SameSite == "Lax" ? SameSiteMode.Lax : SameSiteMode.None;
            options.Cookie.SecurePolicy = setting.Cookie.SecurePolicy ? CookieSecurePolicy.Always : CookieSecurePolicy.None;
        });
        builder.Services.ConfigureOptions<JwtOptionsSetup>();
        builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
        // Add cors
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(setting.Cookie.CorsOrigins, option =>
             option.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
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

        app.MapControllers();

        app.Run();
    }
}