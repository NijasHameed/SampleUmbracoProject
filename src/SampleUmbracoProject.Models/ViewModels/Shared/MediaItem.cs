using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUmbracoProject.Models.ViewModels.Shared
{
    public class MediaItem
    {
        public string Url { get; set; }
        public string CroppedUrl { get; set; }
        public string AltText { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
    }
}
