using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using SampleUmbracoProject.Models.PageModels;
using Microsoft.Extensions.Logging;

namespace SampleUmbracoProject.Core.Controllers
{ 
    public class ContactController : BasePageController<ContactController>
    {
        public ContactController(ILogger<ContactController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IPublishedValueFallback publishedValueFallback) : base(logger, compositeViewEngine, umbracoContextAccessor, publishedValueFallback)
        {
        }
        //execute the base.Index action for tempating
        public override IActionResult Index()
        {
            var baseModel = BasePageService.GetModel(CurrentPage);
            var pageModel = new Contact(CurrentPage,_publishedValueFallback);
            baseModel.PageModel = pageModel;
            return View("~/Views/Contact.cshtml", baseModel);
        }
    }
}
