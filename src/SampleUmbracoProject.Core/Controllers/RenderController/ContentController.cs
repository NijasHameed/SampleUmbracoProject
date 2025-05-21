using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleUmbracoProject.Core.Services;
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
    public class ContentController : BasePageController<ContentController>
    {
        public ContentController(ILogger<ContentController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IPublishedValueFallback publishedValueFallback) : base(logger, compositeViewEngine, umbracoContextAccessor, publishedValueFallback)
        {
        }
        //execute the base.Index action for tempating
        public override IActionResult Index()
        {
            var baseModel = BasePageService.GetModel(CurrentPage);
            var pageModel = new Content(CurrentPage,_publishedValueFallback);
            baseModel.PageModel = pageModel;
            return View("~/Views/Content.cshtml", baseModel);
        }
    }
}
