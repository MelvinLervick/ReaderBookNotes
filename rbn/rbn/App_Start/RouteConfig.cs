using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace rbn
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new
              {
                  controller = "Home",
                  action = "Index",
                  id = UrlParameter.Optional
              }
            );

            routes.MapRoute(
              name: "Author",
              url: "{controller}/{action}/{id}/{enabled}",
              defaults: new
              {
                  controller = "Author",
                  action = "Delete",
                  id = UrlParameter.Optional,
                  enabled = UrlParameter.Optional
              }
            );

            routes.MapRoute(
              name: "Book",
              url: "{controller}/{action}/{id}/{enabled}",
              defaults: new
              {
                  controller = "Book",
                  action = "Delete",
                  id = UrlParameter.Optional,
                  enabled = UrlParameter.Optional
              }
            );
        }
    }
}