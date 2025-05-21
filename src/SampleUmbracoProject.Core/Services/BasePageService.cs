using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SampleUmbracoProject.Models.ViewModels.Shared;
using SampleUmbracoProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;
using SampleUmbracoProject.Models.PageModels;
using Umbraco.Extensions;
using SampleUmbracoProject.Core.Services.Interfaces;

namespace SampleUmbracoProject.Core.Services
{
    internal class BasePageService : IBasePageService
    {
        private ILogger<BasePageService> _logger;
        private static IUmbracoHelperAccessor _umbracoHelperAccessor;
        private readonly IVariationContextAccessor _variationContextAccessor;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly INavigationService _navigationService;

        public BasePageService(ILogger<BasePageService> logger,
            IVariationContextAccessor variationContextAccessor,
            IHttpContextAccessor httpContextAccessor,
            IUmbracoHelperAccessor umbracoHelperAccessor,
            INavigationService navigationService)
        {
            _logger = logger;
            _variationContextAccessor = variationContextAccessor;
            _httpContextAccessor = httpContextAccessor;
            _umbracoHelperAccessor = umbracoHelperAccessor;
            _navigationService = navigationService;
            //_memberManager = memberManager;
        }

        #region Return Base Page Level Model
        public BasePageViewModel GetModel(IPublishedContent current)
        {

            try
            {
                var homePage = current.AncestorOrSelf(1) as Home;
                var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
                var navigation = _navigationService.GetNavigation(current, homePage);
                //var logo = new MediaItem
                //{
                //    Url =homePage.MainLogo.Url(),
                //    AltText = homePage.AltText
                //};
                var baseModel = new BasePageViewModel(current)
                {
                    //Logo = logo,
                    Navigation = navigation,
                    HomePageUrl = homePage.Url(),
                    HomePageModel = homePage,
                    PageHeader=GetPageHeader(homePage),
                };
                return baseModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in BasePageServices -- GetModel");
                throw;
            }
        }
        #endregion
        #region Swicth culture for getting the content against culture
        void SwitchCulture(string culture)
        {
            _variationContextAccessor.VariationContext = new VariationContext(culture);
        }
        #endregion
        #region Footer - Global Content against Culture
        PageHeaderViewModel GetPageHeader(Home homePage)
        {
            try
            {
                return new PageHeaderViewModel
                {
                   BackgroundImage = homePage.MainImage,
                   Name = homePage.Name,
                   Subtitle = homePage.Subtitle,
                   Title = homePage.Title,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in BasePageServices -- GetFooterDetails");
                throw;
            }
        }
        #endregion
    }
}
