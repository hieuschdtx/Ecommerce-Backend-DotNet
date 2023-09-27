using Microsoft.Extensions.Options;
using shopecommerce.Infrastructure.Authentications;

namespace shopecommerce.API.OptionsSetup;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private const string sectionName = "Jwt";
    private readonly IConfiguration _configuration;
    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(sectionName).Bind(options);
    }
}