using System.Security.Claims;

namespace shopecommerce.Domain.Consts
{
    public class ClaimTypeConst
    {
        public const string Id = "id";
        public const string FullName = "full_name";
        public const string Email = "email";
        public const string Phone = "phone_number";
        public const string RoleName = ClaimTypes.Role;
        public const string RefreshToken = "refresh_token";
    }
}