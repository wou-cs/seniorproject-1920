using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AJAX_Example2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            
            routes.MapRoute(
                name: "air",
                url: "Data/here/you/go/AirQuality",
                defaults: new { controller = "Home", action = "AirQuality" }
            );

            routes.MapRoute(
                name: "API",
                url: "Numbers/Random/{action}/{id}",
                defaults: new { controller = "Home", action = "Gimme", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
