using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Web;
using SampleUmbracoProject.Models.PageModels;

namespace SampleUmbracoProject.Core.Controllers
{
    public class HomeController : BasePageController<HomeController>
    {
        public HomeController(ILogger<HomeController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IPublishedValueFallback publishedValueFallback) : base(logger, compositeViewEngine, umbracoContextAccessor, publishedValueFallback)
        {
        }
        //execute the base.Index action for tempating
        public override IActionResult Index()
        {
            var baseModel = BasePageService.GetModel(CurrentPage);
            var pageModel = new Home(CurrentPage,_publishedValueFallback);
            baseModel.PageModel = pageModel;
            return View("~/Views/Home.cshtml", baseModel);
        }
    }
}
