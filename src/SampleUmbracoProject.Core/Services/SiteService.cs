using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core;
using SampleUmbracoProject.Models.PageModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using SampleUmbracoProject.Core.Services.Interfaces;

namespace SampleUmbracoProject.Core.Services
{
    public class SiteService : ISiteService
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;
        private readonly ILogger<SiteService> _logger;

        public SiteService(IUmbracoContextFactory umbracoContextFactory, ILogger<SiteService> logger)
        {
            _umbracoContextFactory = umbracoContextFactory;
            _logger = logger;
        }
        public Settings GetSiteSettings()
        {
            try
            {
                Settings siteSettings;

                using (UmbracoContextReference umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
                {
                    IPublishedContentCache contentHelper = umbracoContextReference.UmbracoContext.Content;
                    var contentType = contentHelper.GetContentType("settings");
                    siteSettings = contentHelper.GetByContentType(contentType).FirstOrDefault() as Settings;
                }

                return siteSettings;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GetSiteSettings | Exception: {0} | Message: {1}", e.InnerException != null ? e.InnerException.ToString() : "", e.Message != null ? e.Message.ToString() : "");
            }

            return null;
        }
    }
}
