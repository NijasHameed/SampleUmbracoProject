using Microsoft.Extensions.Logging;
using SampleUmbracoProject.Core.Services.Interfaces;
using SampleUmbracoProject.Models.PageModels;
using SampleUmbracoProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace SampleUmbracoProject.Core.Services
{
    public class NavigationService : INavigationService
    {
        private readonly ISiteService _siteService;
        private readonly IUmbracoContextFactory _umbracoContextFactory;
        private readonly ILogger<NavigationService> _logger;
        public NavigationService(ISiteService siteService,
           IUmbracoContextFactory umbracoContextFactory,
             ILogger<NavigationService> logger)
        {
            _siteService = siteService;
            _umbracoContextFactory = umbracoContextFactory;
            _logger = logger;
        }

        #region Navigation
        public NavigationViewModel GetNavigation(IPublishedContent current, Home homePage)
        {

            var navigation = new List<NavigationCollection>();
            var mainNav = _siteService.GetSiteSettings().MainNav;
            foreach (var nav in mainNav)
            {
                var menu= GetContentById(nav.Udi);
                var isCurrentPage = current.Id == menu.Id;
                var isHide = menu.Value<bool>("hideFromNavigation");
                if (!isHide)
                {
                    navigation.Add(
                                    new NavigationCollection
                                    {
                                        Name = menu.Name,
                                        Url = menu.Url(),
                                        Active = isCurrentPage,
                                    });
                }
            }
            return new NavigationViewModel { Navigations = navigation };
        }
        #endregion
        public IPublishedContent GetContentById(Udi udi)
        {
            try
            {
                using (UmbracoContextReference umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
                {
                    IPublishedContentCache contentHelper = umbracoContextReference.UmbracoContext.Content;
                    return contentHelper.GetById(udi);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GetContentId | Exception: {0} | Message: {1}", e.InnerException != null ? e.InnerException.ToString() : "", e.Message != null ? e.Message.ToString() : "");
            }

            return null;
        }
    }
}
