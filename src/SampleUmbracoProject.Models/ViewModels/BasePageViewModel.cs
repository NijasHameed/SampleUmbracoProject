using SampleUmbracoProject.Models.PageModels;
using SampleUmbracoProject.Models.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace SampleUmbracoProject.Models.ViewModels
{
    public class BasePageViewModel : ContentModel
    {

        public BasePageViewModel(IPublishedContent content) : base(content)
        {
        }
        public PageBanner PageBanner { get; set; }
        public MediaItem Logo { get; set; }
        public string HomePageUrl { get; set; }
        public IPublishedContent PageModel { get; set; }
        public Home HomePageModel { get; set; }
        public NavigationViewModel Navigation { get; set; }
        public PageHeaderViewModel PageHeader { get; set; }
        public string SearchPage { get; set; }
    }
}
