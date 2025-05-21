using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUmbracoProject.Models.ViewModels
{
    public class NavigationViewModel
    {

        public IEnumerable<NavigationCollection> Navigations { get; set; }
    }
    public class NavigationCollection
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
        public bool hideFromTopNavigation { get; set; }
    }
}
