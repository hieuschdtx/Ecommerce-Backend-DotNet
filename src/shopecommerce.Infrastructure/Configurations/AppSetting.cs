using Microsoft.AspNetCore.Authentication.Cookies;

namespace shopecommerce.Infrastructure.Configurations;

public class AppSetting
{
    public CookieSettings Cookie { get; set; } = new();
    public HeaderKeyStrings headerKeyStrings { get; set; } = new();
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