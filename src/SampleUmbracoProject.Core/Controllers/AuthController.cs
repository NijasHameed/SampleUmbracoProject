using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleUmbracoProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Web.BackOffice.Security;
using Umbraco.Cms.Web.Common.Controllers;

namespace SampleUmbracoProject.Core.Controllers
{
    [Route("auth")]
    public class AuthController : UmbracoController
    {
        private readonly IBackOfficeSignInManager _signInManager;
        private readonly IBackOfficeUserManager _userManager;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            IBackOfficeSignInManager signInManager,
            IBackOfficeUserManager userManager,
            ILogger<AuthController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }
            
        //ASP.NET Core MVC action method... But you can easily modify the code for old .NET Framework, Web-forms etc.
        public async Task<IActionResult> Index()
        {
            try
            {
                // 1. TODO: specify the certificate that your SAML provider gave you
                string samlCertificate = @"-----BEGIN CERTIFICATE-----
-----END CERTIFICATE-----";

                // 2. Let's read the data - SAML providers usually POST it into the "SAMLResponse" var
                var samlResponse = new Response(samlCertificate, Request.Form["SAMLResponse"]);

                // 3. DONE!
                if (samlResponse.IsValid()) //all good?
                {
                    //WOOHOO!!! the user is logged in
                    var email = samlResponse.GetEmail(); //let's get the username

                    //the user has been authenticated
                    //now call context.SignInAsync() for ASP.NET Core
                    //or call FormsAuthentication.SetAuthCookie() for .NET Framework
                    //or do something else, like set a cookie or something...

                    //FOR EXAMPLE this is how you sign-in a user in ASP.NET Core 3,5,6,7
                    //await context.SignInAsync(new ClaimsPrincipal(
                    //    new ClaimsIdentity(
                    //        new[] { new Claim(ClaimTypes.Name, username) },
                    //        CookieAuthenticationDefaults.AuthenticationScheme)));
                    var user = await _userManager.FindByEmailAsync(email);
                    await _signInManager.SignInAsync(user, true);

                    return Redirect("~/umbraco");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error, {ex.Message}");
                throw;
            }
            return Content("Unauthorized");
        }
    }
}
