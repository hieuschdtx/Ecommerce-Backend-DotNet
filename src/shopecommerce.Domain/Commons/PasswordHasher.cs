using System.Security.Cryptography;
using System.Text;

namespace shopecommerce.Domain.Commons
{
    public static class PasswordHasher
    {
        public static (string hashedPassword, string salt) HashPassword(string password)
        {
            byte[ ] salt = new byte[16];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            using(var hasher = new SHA256Managed())
            {
                byte[ ] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[ ] saltedPasswordBytes = new byte[passwordBytes.Length + salt.Length];

                // Kết hợp mật khẩu và salt
                Buffer.BlockCopy(passwordBytes, 0, saltedPasswordBytes, 0, passwordBytes.Length);
                Buffer.BlockCopy(salt, 0, saltedPasswordBytes, passwordBytes.Length, salt.Length);

                byte[ ] hashedPasswordBytes = hasher.ComputeHash(saltedPasswordBytes);
                string hashedPassword = Convert.ToBase64String(hashedPasswordBytes);
                string saltString = Convert.ToBase64String(salt);

                return (hashedPassword, saltString);
            }
        }
        public static bool VerifyPassword(string enteredPassword, string hashedPassword, string salt)
        {
            byte[ ] saltBytes = Convert.FromBase64String(salt);
            byte[ ] enteredPasswordBytes = Encoding.UTF8.GetBytes(enteredPassword);
            byte[ ] saltedPasswordBytes = new byte[enteredPasswordBytes.Length + saltBytes.Length];

            // Kết hợp mật khẩu nhập và salt
            Buffer.BlockCopy(enteredPasswordBytes, 0, saltedPasswordBytes, 0, enteredPasswordBytes.Length);
            Buffer.BlockCopy(saltBytes, 0, saltedPasswordBytes, enteredPasswordBytes.Length, saltBytes.Length);

            using(var hasher = new SHA256Managed())
            {
                byte[ ] hashedEnteredPasswordBytes = hasher.ComputeHash(saltedPasswordBytes);
                string hashedEnteredPassword = Convert.ToBase64String(hashedEnteredPasswordBytes);

                // So sánh mật khẩu đã nhập và mật khẩu đã băm
                return string.Equals(hashedPassword, hashedEnteredPassword);
            }
        }
    }
}
