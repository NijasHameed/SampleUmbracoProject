using SampleUmbracoProject.Models.PageModels;

namespace SampleUmbracoProject.Core.Services.Interfaces
{
    public interface ISiteService
    {
        Settings GetSiteSettings();
    }
}