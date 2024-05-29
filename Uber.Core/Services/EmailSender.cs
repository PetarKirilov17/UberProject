using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Core.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;   
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                       ILogger<EmailSender> logger)
        {
            Options = optionsAccessor.Value;
            _logger = logger;
        }

        public AuthMessageSenderOptions Options { get; }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            if (string.IsNullOrEmpty(Options.SendGridKey))
            {
                throw new Exception("Null SendGridKey");
            }

            await Execute(Options.SendGridKey, subject, htmlMessage, email);
        }

        public async Task Execute(string apiKey, string subject, string htmlMessage, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("petar.kirilov17@gmail.com", "Password recovery"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };
            msg.AddTo(new EmailAddress(email));

            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);

            _logger.LogInformation(response.IsSuccessStatusCode ? $"Email to {email} was successfully sent!"
                : $"Email to {email} failed!");
        }
    }
}
