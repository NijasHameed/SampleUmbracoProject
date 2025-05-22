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
using Umbraco.Cms.Core.Configuration.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Web;
using Umbraco.Cms.Core.Strings;

namespace SampleUmbracoProject.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly GlobalSettings _globalSettings;
        private readonly ILogger<EmailService> _logger;
        private readonly ISiteService _siteService;
        public EmailService(IConfiguration configuration, IOptionsMonitor<GlobalSettings> globalSettings,ISiteService siteService ,ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _globalSettings = globalSettings.CurrentValue;
            _siteService = siteService;
            _logger = logger;
        }

        public void SendFormEmail(ContactFormModel model, bool isAdminEmail=false)
        {
            try
            {
                using (var client = new SmtpClient(_globalSettings.Smtp.Host, _globalSettings.Smtp.Port))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(
                       _globalSettings.Smtp.Username,
                        _globalSettings.Smtp.Password);

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_globalSettings.Smtp.From,_globalSettings.Smtp.From),
                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(model.Email);
                    if (isAdminEmail)
                    {
                        mailMessage.Subject = _siteService.GetSiteSettings().EmailSubject;
                        mailMessage.Body = FormatEmailBody(_siteService.GetSiteSettings().AdminEmailBody, model);
                        mailMessage = AddCc(_siteService.GetSiteSettings().CC, mailMessage);
                        mailMessage = AddCc(_siteService.GetSiteSettings().Bcc, mailMessage);
                    }
                    else
                    {
                        mailMessage.Subject = _siteService.GetSiteSettings().RecipientEmailSubject;
                        mailMessage.Body = FormatEmailBody(_siteService.GetSiteSettings().RecipientEmailBody, model);
                    }

                    client.Send(mailMessage);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "SendFormEmail | Exception: {0} | Message: {1}", e.InnerException != null ? e.InnerException.ToString() : "", e.Message != null ? e.Message.ToString() : "");
            }
        }

        private string FormatEmailBody(IHtmlEncodedString emailBody,ContactFormModel model)
        {
            return emailBody.ToHtmlString().Replace("{Title}", model.Title)
                .Replace("{Name}", model.Name)
                .Replace("{Dob}", model.DateOfBirth?.ToString("d"))
                .Replace("{email}", model.Email)
                .Replace("{Message}", model.Message)
                .Replace("{Date}", DateTime.Now.ToString("f"));
        }
        private MailMessage AddCc(string commaList, MailMessage m)
        {
            try
            {
                if (!string.IsNullOrEmpty(commaList))
                {
                    string[] list = commaList.Split(',');
                    if (list != null && list.Length > 0)
                    {
                        foreach (string emailAddress in list)
                        {
                            m.CC.Add(emailAddress);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "AddCc | Exception: {0} | Message: {1}", e.InnerException != null ? e.InnerException.ToString() : "", e.Message != null ? e.Message.ToString() : "");
            }

            return m;
        }

        private MailMessage AddBcc(string commaList, MailMessage m)
        {
            try
            {
                if (!string.IsNullOrEmpty(commaList))
                {
                    string[] list = commaList.Split(',');
                    if (list != null && list.Length > 0)
                    {
                        foreach (string emailAddress in list)
                        {
                            m.Bcc.Add(emailAddress);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "AddBcc | Exception: {0} | Message: {1}", e.InnerException != null ? e.InnerException.ToString() : "", e.Message != null ? e.Message.ToString() : "");
            }

            return m;
        }
    }
}
