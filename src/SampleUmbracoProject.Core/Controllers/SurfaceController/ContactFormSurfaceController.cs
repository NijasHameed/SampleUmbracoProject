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

namespace SampleUmbracoProject.Core.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IVariationContextAccessor _variationContextAccessor;
        private readonly IEmailService _emailService;
        public ContactFormSurfaceController(
        IUmbracoContextAccessor umbracoContextAccessor,
        IUmbracoDatabaseFactory databaseFactory,
        ServiceContext services,
        AppCaches appCaches,
        IProfilingLogger profilingLogger,
        IPublishedUrlProvider publishedUrlProvider,
        IPublishedContentQuery publishedContentQuery,
        IVariationContextAccessor variationContextAccessor,
        IEmailService emailService)
        : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _publishedContentQuery = publishedContentQuery;
            _variationContextAccessor = variationContextAccessor;
            _emailService = emailService;
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
                _emailService.SendFormEmail(model);

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
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while submitting the form. Please try again later.");
                return View("Default", model);
            }
        }

       
    }
}
