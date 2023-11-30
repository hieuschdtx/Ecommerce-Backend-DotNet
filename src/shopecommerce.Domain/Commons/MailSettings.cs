namespace shopecommerce.Domain.Commons
{
    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
    public class MailContent
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
    public static class GenerateOTP
    {
        public static string OTP()
        {
            Random random = new();
            int otp = random.Next(100000, 999999);
            return otp.ToString("D6");
        }
    }
}
