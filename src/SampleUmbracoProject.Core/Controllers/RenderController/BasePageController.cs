using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using SampleUmbracoProject.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace SampleUmbracoProject.Core.Controllers
{
    public abstract class BasePageController<T> : RenderController where T : BasePageController<T>
    {

        private ILogger<T> _logger;
        internal IPublishedValueFallback _publishedValueFallback;
        protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetService<ILogger<T>>();

        private IBasePageService _basePageService;
        internal IBasePageService BasePageService => _basePageService ??= HttpContext.RequestServices.GetService<IBasePageService>();
        public BasePageController(ILogger<T> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IPublishedValueFallback publishedValueFallback)
         : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _logger = logger;
            _publishedValueFallback = publishedValueFallback;
        }

        //[ResponseCache(CacheProfileName = "Weekly")]//in seconds applied for all
        public override IActionResult Index() => base.Index();
    }
}
