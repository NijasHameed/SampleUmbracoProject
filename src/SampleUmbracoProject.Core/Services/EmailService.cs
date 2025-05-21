using SampleUmbracoProject.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SampleUmbracoProject.Core.Services.Interfaces;

namespace SampleUmbracoProject.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendFormEmail(ContactFormModel model)
        {
            var smtpSettings = _configuration.GetSection("SmtpSettings");
            var recipientEmail = _configuration["EmailSettings:RecipientEmail"] ?? "default@example.com";

            using (var client = new SmtpClient(smtpSettings["Host"], int.Parse(smtpSettings["Port"])))
            {
                client.EnableSsl = bool.Parse(smtpSettings["EnableSsl"]);
                client.Credentials = new NetworkCredential(
                    smtpSettings["Username"],
                    smtpSettings["Password"]);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSettings["FromEmail"], smtpSettings["FromName"]),
                    Subject = "New Contact Form Submission",
                    Body = FormatEmailBody(model),
                    IsBodyHtml = true
                };

                mailMessage.To.Add(recipientEmail);
                client.Send(mailMessage);
            }
        }

        private string FormatEmailBody(ContactFormModel model)
        {
            return $@"
                <h1>New Contact Form Submission</h1>
                <p><strong>Title:</strong> {model.Title}</p>
                <p><strong>Name:</strong> {model.Name}</p>
                <p><strong>Date of Birth:</strong> {model.DateOfBirth?.ToString("d")}</p>
                <p><strong>Email:</strong> {model.Email}</p>
                <p><strong>Message:</strong></p>
                <p>{model.Message}</p>
                <p>Submitted on: {DateTime.Now.ToString("f")}</p>
            ";
        }
    }
}
