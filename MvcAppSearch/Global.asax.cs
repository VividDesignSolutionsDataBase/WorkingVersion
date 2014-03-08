/* Author:    Niloufar Mohaseb
 * E-mail:    Niloufar.rad@gmail.com
 * Title:     JSO DR Form
 * Date:      Fall 2013
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;


namespace MvcAppSearch
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        public void Session_Start(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {

                //old authentication, kill it
                FormsAuthentication.SignOut();
                //or use Response.Redirect to go to a different page
                FormsAuthentication.RedirectToLoginPage("Session=Expired");
                HttpContext.Current.Response.End();
            }

        }

        }

        


    }
