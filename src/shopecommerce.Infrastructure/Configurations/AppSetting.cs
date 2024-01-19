using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace shopecommerce.Infrastructure.Configurations;

public class AppSetting
{
    public CookieSettings cookieSettings { get; set; } = new();
    public HeaderKeyStrings headerKeyStrings { get; set; } = new();
    public JwtBearerSetting jwtBearerSetting { get; set; } = new();
}

public class CookieSettings
{
    public string CorsOrigins { get; set; } = "*";
    public string Domain { get; set; } = "localhost";
    public bool HttpOnly { get; set; } = true;
    public string Name { get; set; } = CookieAuthenticationDefaults.AuthenticationScheme;
    public string SameSite { get; set; } = "Lax";
    public bool SecurePolicy { get; set; } = true;
    public int Expires { get; set; } = 1;
    // None/Lax/Strict
    // false: devlop
}

public class HeaderKeyStrings
{
    public string Panigation { get; private set; } = "X-Panigation";
}

public class JwtBearerSetting
{
    public string Name = JwtBearerDefaults.AuthenticationScheme;
}