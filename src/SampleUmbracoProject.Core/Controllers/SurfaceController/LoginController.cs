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
    public class LoginController : SurfaceController
    {
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IVariationContextAccessor _variationContextAccessor;
        private readonly IEmailService _emailService;
        private readonly IContactFormService _contactFormService;
        private readonly ILogger<LoginController> _logger;
        public LoginController(
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
        ILogger<LoginController> logger)
        : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _publishedContentQuery = publishedContentQuery;
            _variationContextAccessor = variationContextAccessor;
            _emailService = emailService;
            _contactFormService = contactFormService;
            _logger = logger;
        }

        public IActionResult Login()
        {
            //TODO: specify the SAML provider url here, aka "Endpoint"
            var samlEndpoint = "https://auth.pingone.com.au/f5c7aad0-59a9-4701-b8d4-d8895353ff03/saml20/idp/sso";
            var request = new AuthRequest(
                "umb-sso",
                "http://localhost:5800/Auth"
            );

            //now send the user to the SAML provider
            return Redirect(request.GetRedirectUrl(samlEndpoint));
        }
    }
}
