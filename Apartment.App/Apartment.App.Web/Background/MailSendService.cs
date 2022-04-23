using System;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Apartment.App.Web.Models.MailModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Apartment.App.Web.Background
{
    public interface IMailSendService
    {
        Task<string> SendEmailAsync(Mail mail, CancellationToken cancellationToken = default);
    }
    public class MailSendService : IMailSendService

    {
        private readonly ILogger<MailSendService> _logger;
        private readonly SmtpSettings _smtpSettings;

        public MailSendService(ILogger<MailSendService> logger, IOptions<SmtpSettings> smtpSettings)
        {
            _logger = logger;
            _smtpSettings = smtpSettings.Value;
        }

        public async Task<string> SendEmailAsync(Mail mail, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("{To} adresine {Subject} konulu {Body} maili gönderilecek!", mail.To, mail.Subject, mail.Body);
            await Task.Delay(3000, cancellationToken);
            
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_smtpSettings.SenderEmail));
            message.To.Add(MailboxAddress.Parse(mail.To));
            message.Subject = mail.Subject;
            message.Body = new TextPart("plain")
            {
                Text = mail.Body
            };

            var client = new SmtpClient();

            try
            {
                await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, true);
                await client.AuthenticateAsync(new NetworkCredential(_smtpSettings.SenderEmail, _smtpSettings.Password));
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                _logger.LogInformation("{To} adresine {Subject} konulu {Body} maili gönderildi!", mail.To, mail.Subject ,mail.Body);
                return "Email Sent Successfully";
            }
            catch (Exception ex)
            {
                _logger.LogCritical("{To} adresine {Subject} konulu {Body} maili gönderilirken hata oluştu!", mail.To, mail.Subject, mail.Body);
                _logger.LogWarning("{message} Hatası alındı tekrar deneyiniz", ex.Message);
                return "Email Sent Failed";
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
