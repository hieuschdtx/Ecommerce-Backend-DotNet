namespace shopecommerce.Domain.Commons
{
    public class PasswordHasher
    {
        public static string HassPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        public static bool VerifyPassword(string hashedPassword, string providedPassword) => BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
    }
}
