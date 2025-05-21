using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleUmbracoProject.Models.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace SampleUmbracoProject.Core.Controllers
{
    public class ErrorController : BasePageController<ErrorController>
    {
        public ErrorController(ILogger<ErrorController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IPublishedValueFallback publishedValueFallback) : base(logger, compositeViewEngine, umbracoContextAccessor, publishedValueFallback)
        {
        }
        //execute the base.Index action for tempating
        public override IActionResult Index()
        {
            var baseModel = BasePageService.GetModel(CurrentPage);
            var pageModel = new Error(CurrentPage,_publishedValueFallback);
            baseModel.PageModel = pageModel;
            return View("~/Views/error.cshtml", baseModel);
        }
    }
}
