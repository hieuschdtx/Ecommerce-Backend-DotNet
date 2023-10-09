using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Consts;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Infrastructure.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;

namespace shopecommerce.Infrastructure.Authentications;

public class JwtProvider : IJwtProvider
{
    private readonly AppSetting _appSetting = new();
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly JwtOptions _jwtOptions;
    private readonly IRoleRepository _roleRepository;
    private readonly JwtValidation _jwtValidation;

    public JwtProvider(
        IOptions<JwtOptions> jwtOptions,
        IHttpContextAccessor httpContextAccessor,
        JwtValidation jwtValidation,
        IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
        _jwtOptions = jwtOptions.Value;
        _httpContextAccessor = httpContextAccessor;
        _jwtValidation = jwtValidation;
    }

    public async Task<string> GenerateAccessTokenAsync(Users user)
    {
        var role = await _roleRepository.GetByIdAsync(user.role_id);
        var claims = new Claim[]
        {
            new(ClaimTypeConst.Id, user.id),
            new(ClaimTypeConst.FullName, user.full_name),
            new(ClaimTypeConst.Email, user.email!),
            new(ClaimTypeConst.Phone, user.phone_number!),
            new(ClaimTypes.Role, role.name),
            new(ClaimTypeConst.RefreshToken, user.refresh_token)
        };

        var identity = new ClaimsIdentity(claims, _appSetting.Cookie.Name);

        var token = new JwtSecurityToken(
           _jwtOptions.Issuer,
           _jwtOptions.Audience,
           claims,
           null,
           DateTime.UtcNow.AddHours(_jwtValidation.ExpireTime),
           _jwtValidation.GetSigning());

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

        await SigningAsync(identity);
        return accessToken;
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public void SaveCookiesStorage(string token)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = _appSetting.Cookie.HttpOnly,
            SameSite = _appSetting.Cookie.SameSite == "Lax" ? SameSiteMode.Lax : SameSiteMode.None,
            Secure = _appSetting.Cookie.SecurePolicy,
            Expires = DateTime.UtcNow.AddYears(_appSetting.Cookie.Expires)
        };
        _httpContextAccessor.HttpContext.Response.Cookies.Append(JwtBearerDefaults.AuthenticationScheme, token, cookieOptions);
    }

    public async Task SignOutAsync()
    {
        await _httpContextAccessor.HttpContext.SignOutAsync(_appSetting.Cookie.Name);
        _httpContextAccessor.HttpContext.Response.Cookies.Delete(JwtBearerDefaults.AuthenticationScheme);
    }

    private async Task SigningAsync(IIdentity claimsIdentity)
    {
        var principal = new ClaimsPrincipal(claimsIdentity);

        await _httpContextAccessor.HttpContext.SignInAsync(_appSetting.Cookie.Name, principal);
    }
}