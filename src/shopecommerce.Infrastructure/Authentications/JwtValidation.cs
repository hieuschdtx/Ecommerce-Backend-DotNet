using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace shopecommerce.Infrastructure.Authentications;

public abstract class JwtValidation
{
   private readonly JwtOptions _jwtOptions;

   private SymmetricSecurityKey? _securityKey;

   protected JwtValidation(IOptions<JwtOptions> jwtOptions)
   {
      _jwtOptions = jwtOptions.Value;
   }

   public int ExpireDays { get; set; } = 1;

   public SymmetricSecurityKey SecurityKey
   {
      get
      {
         return _securityKey ??= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey ?? "SecretKey"));
      }
   }

   public SigningCredentials GetSigning()
   {
      return new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
   }

   public EncryptingCredentials GetEncrypting()
   {
      return new EncryptingCredentials(SecurityKey, JwtConstants.DirectKeyUseAlg,
         SecurityAlgorithms.Aes128CbcHmacSha256);
   }
}