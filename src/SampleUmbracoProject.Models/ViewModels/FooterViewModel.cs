using SampleUmbracoProject.Models.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models;

namespace SampleUmbracoProject.Models.ViewModels
{
    public class FooterViewModel
    {
        //public IEnumerable<SocialMediaIcons> SocialMedia { get; set; }
        public MediaItem Logo { get; set; }
        public IEnumerable<Link> Links { get; set; }
        public string HomePageUrl { get; set; }
        public string CopyRightText { get; set; }
        public string TwitterPageUrl { get; set; }
        public string YoutubePageUrl { get; set; }
        public string FacebookPageUrl { get; set; }
        public string InstagramPageUrl { get; set; }
    }
}
