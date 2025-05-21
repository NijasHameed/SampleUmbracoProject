using SampleUmbracoProject.Models.PageModels;
using SampleUmbracoProject.Models.ViewModels;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace SampleUmbracoProject.Core.Services.Interfaces
{
    public interface INavigationService
    {
        IPublishedContent GetContentById(Udi udi);
        NavigationViewModel GetNavigation(IPublishedContent current, Home homePage);
    }
}