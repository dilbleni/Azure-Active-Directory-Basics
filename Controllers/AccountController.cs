using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// The following using statements were added for this sample.
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.WsFederation;
using Microsoft.Owin.Security;

namespace DNCMvcApp.Controllers
{
    public class AccountController : Controller
    {
        public void SignIn()
        {
            // Send a WSFederation sign-in request.
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" }, WsFederationAuthenticationDefaults.AuthenticationType);
            }
        }
        public void SignOut()
        {
            // Send a WSFederation sign-out request.
            HttpContext.GetOwinContext().Authentication.SignOut(
                WsFederationAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
        }
    }
}