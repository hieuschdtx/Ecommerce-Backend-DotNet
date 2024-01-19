using shopecommerce.Domain.Commons;

namespace shopecommerce.Domain.Interfaces
{
    public interface ISendMailRepository
    {
        Task<bool> SendMail(MailContent mailContent);
        Task<bool> SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
