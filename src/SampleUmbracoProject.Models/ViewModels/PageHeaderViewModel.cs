using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace SampleUmbracoProject.Models.ViewModels
{
    public class PageHeaderViewModel
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }
        public bool HasSubtitle => !string.IsNullOrWhiteSpace(Subtitle);

        public IPublishedContent BackgroundImage { get; set; }

        public bool HasBackgroundImage => BackgroundImage != null;
    }
}
