using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Cars_Bikes.Models;

namespace Cars_Bikes.Services
{
    public class EmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(
            string toEmail,
            string subject,
            string body)
        {
            var message = new MailMessage
            {
                From = new MailAddress(_settings.Email),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            message.To.Add(toEmail);

            using var smtp = new SmtpClient(
                _settings.Host,
                _settings.Port)
            {
                Credentials = new NetworkCredential(
                    _settings.Email,
                    _settings.Password
                ),

                EnableSsl = true
            };

            await smtp.SendMailAsync(message);
        }
    }
}