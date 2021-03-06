﻿using System.Web.Mvc;
using System.Web.Routing;
using TravelNM.Helpers;

namespace TravelNM
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DefaultLocalized",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new { culture = CultureHelper.GetDefaultCulture(), controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}