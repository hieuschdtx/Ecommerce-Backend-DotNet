using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using shopecommerce.Infrastructure.Authentications;

namespace shopecommerce.API.OptionsSetup;

public class JwtBearerOptionsSetup : IConfigureOptions<JwtBearerOptions>
{
    private readonly JwtOptions _jwtOptions;
    private readonly JwtValidation _jwtValidation;

    public JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions, JwtValidation jwtValidation)
    {
        _jwtOptions = jwtOptions.Value;
        _jwtValidation = jwtValidation;
    }

    public void Configure(JwtBearerOptions options)
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwtOptions.Issuer,
            ValidAudience = _jwtOptions.Audience,
            IssuerSigningKey = _jwtValidation.SecurityKey
        };
    }
}