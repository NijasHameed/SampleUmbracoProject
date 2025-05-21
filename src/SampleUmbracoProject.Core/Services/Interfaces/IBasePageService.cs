using SampleUmbracoProject.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace SampleUmbracoProject.Core.Services.Interfaces
{
    internal interface IBasePageService
    {
        BasePageViewModel GetModel(IPublishedContent current);
    }
}