using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using SampleUmbracoProject.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using Umbraco.Cms.Core;
using SampleUmbracoProject.Models.FormModels;
using Umbraco.Extensions;
using Umbraco.Cms.Core.Web;

namespace SampleUmbracoProject.Core.ViewComponents
{
    public class ContactFormViewComponent : ViewComponent
    {

        public ContactFormViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default", new ContactFormModel());
        }

        
    }
}
