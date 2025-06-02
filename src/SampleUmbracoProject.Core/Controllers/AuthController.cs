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
MIIDejCCAmKgAwIBAgIGAZcsMI6kMA0GCSqGSIb3DQEBCwUAMH4xCzAJBgNVBAYT
AlVTMRYwFAYDVQQKDA1QaW5nIElkZW50aXR5MRYwFAYDVQQLDA1QaW5nIElkZW50
aXR5MT8wPQYDVQQDDDZQaW5nT25lIFNTTyBDZXJ0aWZpY2F0ZSBmb3IgQWRtaW5p
c3RyYXRvcnMgZW52aXJvbm1lbnQwHhcNMjUwNjAxMTU1MTA5WhcNMjYwNjAxMTU1
MTA5WjB+MQswCQYDVQQGEwJVUzEWMBQGA1UECgwNUGluZyBJZGVudGl0eTEWMBQG
A1UECwwNUGluZyBJZGVudGl0eTE/MD0GA1UEAww2UGluZ09uZSBTU08gQ2VydGlm
aWNhdGUgZm9yIEFkbWluaXN0cmF0b3JzIGVudmlyb25tZW50MIIBIjANBgkqhkiG
9w0BAQEFAAOCAQ8AMIIBCgKCAQEA7uv97+INrcMNiBVsOxWQ5JME3Ymv2DdKcfkH
SVG6rKq/P4DTcqqT5r1avVOM4plUXW1yoak2Yc4hNB2JKQ5dTVwy8v6NHwWObxDc
AH+svhWsY7j6EC+luT8q96mLRVCGFZMWthvqVka0kYzDkGWmBczj+3Lam+V1qKYD
baklJDtaFF6449AdfO6jxtaD+wBuMEx0zAH6h8lQh6rTyhPKQa/vcEQSfAD2jmLH
/GaeLsClDlsB3KFCbM3TOJDDWG1mTj0HaUedQtrstF3eQeKiZUypj7N50L3bBVDa
rs0dc3dwWNIlZgUScmvukZYbtlEKeKOoFO7fdkQgdlEOuXVd5wIDAQABMA0GCSqG
SIb3DQEBCwUAA4IBAQAPM9rk19TTSvy/kHjkO+9A8yvTxVRF+0c9gzUGasnux764
MIhyA2zm+LwMpEtL4bAlBkJIrthCoYGsU/7U4L8J86KRUjfaukF9XtY6xm2ZnW1N
KoBvPxWp6gX0ewf+MQX/PIuMb83DJtarMMjoRk/O5ew4YUOIumPI57/2oNaXuh+3
LBB+zCjpMlB2dYKY0bUDXlj2JMk3et8k+Ig0iGYZMhAP7WkMm8bCYzz6KYfoJgt0
gJBJSUiqwu2M5uO7ioTlwmGkOy6iAOua5zjFmZwFm/YEIR0dkr8du8dfYmARf3qr
YHjKzlVifNLsUFA/4zx8lkIo+tXVJyvULu6SPUgK
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
