using Application.IServices;
using Application.Settings;
using Application.Wrapper;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Services
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;

        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendAsync(string from, string to, string subject, string html)
        {
            try
            {
                // create message
                var email = new MimeMessage();
                email.Sender = new MailboxAddress(_mailSettings.DisplayName,_mailSettings.EmailFrom);
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = html;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

            }
            catch (System.Exception ex)
            {
                Log.Information(ex.Message);
            }
        }
    }
}
