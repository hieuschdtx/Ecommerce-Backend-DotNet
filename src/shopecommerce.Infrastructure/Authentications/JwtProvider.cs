using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Infrastructure.Configurations;

namespace shopecommerce.Infrastructure.Authentications;

public class JwtProvider : IJwtProvider
{
   private readonly AppSetting _appSetting;
   private readonly HttpContext _httpContext;
   private readonly JwtOptions _jwtOptions;
   private readonly JwtValidation _jwtValidation;

   public JwtProvider(IOptions<JwtOptions> jwtOptions, JwtValidation jwtValidation, HttpContext httpContext,
      AppSetting appSetting)
   {
      _jwtValidation = jwtValidation;
      _jwtOptions = jwtOptions.Value;
      _httpContext = httpContext;
      _appSetting = appSetting;
   }

   public async Task<string> GenerateAsync(Users user)
   {
      var claims = new Claim[]
      {
         new("id", user.id),
         new("full_name", user.full_name),
         new("email", user.email!),
         new("phone", user.phone_number!),
         new("role_id", user.role_id)
      };

      var identity = new ClaimsIdentity(claims, _appSetting.Cookie.Name);

      var accessToken = new JwtSecurityTokenHandler().CreateEncodedJwt(
         _jwtOptions.Issuer,
         _jwtOptions.Audience,
         notBefore: null,
         subject: identity,
         issuedAt: DateTime.UtcNow,
         expires: DateTime.UtcNow.AddHours(1),
         signingCredentials: _jwtValidation.GetSigning(),
         encryptingCredentials: _jwtValidation.GetEncrypting());

      await SigningAsync(identity);
      return accessToken;
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

      _httpContext.Response.Cookies.Append("access_token", token, cookieOptions);
   }

   public async Task SignOutAsync()
   {
      await _httpContext.SignOutAsync(_appSetting.Cookie.Name);
   }

   private async Task SigningAsync(IIdentity claimsIdentity)
   {
      var principal = new ClaimsPrincipal(claimsIdentity);

      await _httpContext.SignInAsync(_appSetting.Cookie.Name, principal);
   }
}