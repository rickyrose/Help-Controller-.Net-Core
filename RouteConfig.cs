using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RickyRose
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRute("{resource}.axd/{*pathinfo}");

            routes.MapRoute(
                name: "Default",
                url: "{Controller}/{action}",
                defaults: new {controller = "base", action = "home"}
            );
            routes.MapRoute("AuthIndex", "000x00000000x000000000x00000x0", new {controller = "Saml2", action = "Index" });
            routes.MapRoute("AuthAcs", "0000x000x000x000x0x0x00xx0000x/Acs", new { controller = "Saml2", action = "Acs" });
            routes.MapRoute("SignIn", "00000x000x0000x0000x000x000x00/SignIn", new { controller = "Saml2", action = "SignIn" });
            routes.MapRoute("Logout", "000x00x000x000x000x000x000x00/Logout", new { controller = "Saml2", action = "SignOut"});
        }
    }
}