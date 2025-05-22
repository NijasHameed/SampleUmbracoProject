using Microsoft.Extensions.DependencyInjection;
using SampleUmbracoProject.Core.Services.Interfaces;
using SampleUmbracoProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
using SampleUmbracoProject.Core.Repositories.Interfaces;
using SampleUmbracoProject.Core.Repositories;

namespace SampleUmbracoProject.Core.DI
{
    public static class ServiceInjection
    {
        public static IUmbracoBuilder AddCustomServices(this IUmbracoBuilder builder)
        {
            builder.Services.AddSingleton<IBasePageService, BasePageService>();
            builder.Services.AddSingleton<IEmailService, EmailService>();
            builder.Services.AddSingleton<ISiteService, SiteService>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddTransient<IContactFormRepository, ContactFormRepository>();
            builder.Services.AddTransient<IContactFormService, ContactFormService>();
            return builder;

        }
    }
}
