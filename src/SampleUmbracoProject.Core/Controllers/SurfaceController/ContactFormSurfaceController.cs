using Microsoft.AspNetCore.Mvc;
using SampleUmbracoProject.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Cms.Core;
using Umbraco.Extensions;
using Microsoft.Extensions.Configuration;
using SampleUmbracoProject.Core.Services.Interfaces;
using SampleUmbracoProject.Core.Services;
using Microsoft.Extensions.Logging;

namespace SampleUmbracoProject.Core.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IVariationContextAccessor _variationContextAccessor;
        private readonly IEmailService _emailService;
        private readonly IContactFormService _contactFormService;
        private readonly ILogger<ContactFormSurfaceController> _logger;
        public ContactFormSurfaceController(
        IUmbracoContextAccessor umbracoContextAccessor,
        IUmbracoDatabaseFactory databaseFactory,
        ServiceContext services,
        AppCaches appCaches,
        IProfilingLogger profilingLogger,
        IPublishedUrlProvider publishedUrlProvider,
        IPublishedContentQuery publishedContentQuery,
        IVariationContextAccessor variationContextAccessor,
        IEmailService emailService,
        IContactFormService contactFormService,
        ILogger<ContactFormSurfaceController> logger)
        : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _publishedContentQuery = publishedContentQuery;
            _variationContextAccessor = variationContextAccessor;
            _emailService = emailService;
            _contactFormService = contactFormService;
            _logger = logger;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitForm(ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Default", model);
            }

            try
            {
                _contactFormService.SaveContactFormSubmission(model);
                _emailService.SendFormEmail(model,isAdminEmail:true);
                _emailService.SendFormEmail(model, isAdminEmail: false);

                var thankYouPage = _publishedContentQuery.ContentAtRoot()
                    .FirstOrDefault()?
                    .DescendantsOrSelfOfType(_variationContextAccessor,"thankYouPage")
                    .FirstOrDefault();

                if (thankYouPage != null)
                {
                    return Redirect(thankYouPage.Url());
                }

                ViewData["FormSuccess"] = true;
                return View("Default", model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "An error occurred while submitting the form. Please try again later.");
                _logger.LogError(e, "SubmitForm | Exception: {0} | Message: {1}", e.InnerException != null ? e.InnerException.ToString() : "", e.Message != null ? e.Message.ToString() : "");
                return View("Default", model);
            }
        }

       
    }
}
