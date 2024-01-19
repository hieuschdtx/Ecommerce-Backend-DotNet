using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Interfaces;

namespace shopecommerce.Infrastructure.Repositories
{
    public class SendMailRepository : ISendMailRepository
    {
        private readonly MailSettings _mailSettings;

        public SendMailRepository(MailSettings mailSettings)
        {
            _mailSettings = mailSettings;
        }

        public async Task<bool> SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return await SendMail(new MailContent()
            {
                To = email,
                Subject = subject,
                Body = htmlMessage
            });
        }

        public async Task<bool> SendMail(MailContent mailContent)
        {
            var email = new MimeMessage
            {
                Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail)
            };

            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            email.To.Add(MailboxAddress.Parse(mailContent.To));
            email.Subject = mailContent.Subject;

            var builder = new BodyBuilder
            {
                HtmlBody = mailContent.Body
            };

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            try
            {
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
                return true;
            }
            catch(Exception)
            {
                // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
                Directory.CreateDirectory("mailssave");
                var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                await email.WriteToAsync(emailsavefile);
                return false;
            }
        }
    }
}
