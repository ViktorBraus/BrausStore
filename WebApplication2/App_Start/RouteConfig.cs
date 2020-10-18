using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUA1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
           null,
           "",
           new { controller = "Books", action = "List", page = 1 }
           );

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Books", action = "List", genre = (string)null },
                constraints: new { page = @"\d+" }
                );

            routes.MapRoute(
               null,
                "{genre}",
                 new { controller = "Books", action = "List", page = 1 }
                );
            routes.MapRoute(
           null,
          "{controller}/{action}"
           );
        }
       
    }
}
