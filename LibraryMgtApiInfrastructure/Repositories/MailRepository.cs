
using LibraryMgtApiDomain.CustomEmailEntity;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Repositories;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgtApiInfrastructure.Repositories
{
    
    public class MailRepository : IMailRepository
    {
        private readonly EmailSettings _emailSettings;
        public MailRepository(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task SendEmailAsync(string toEmail, string username, string subject)
        {
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "DynamicEmailTemplate/Templates", "AccountCreatedTemplate.html");
            string htmlTemplate = await File.ReadAllTextAsync(templatePath);

            htmlTemplate = htmlTemplate.Replace("{{Username}}", username);
            htmlTemplate = htmlTemplate.Replace("{{Email}}", toEmail);
            htmlTemplate = htmlTemplate.Replace("{{Subject}}", subject);

            using (SmtpClient client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port))
            {
                client.EnableSsl = _emailSettings.EnableSsl;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.AppPassword);

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailSettings.SenderEmail),
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = htmlTemplate
                };

                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
