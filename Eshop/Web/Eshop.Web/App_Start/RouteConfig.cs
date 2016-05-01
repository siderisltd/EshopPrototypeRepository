using System.Web.Mvc;
using System.Web.Routing;

namespace Eshop.Web
{
    using Helpers.RouteConstraints;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "SearchByCategory",
                url: "{culture}/Items/ByCategory/{name}",
                defaults: new { controller = "Items", action = "ByCategory" });

            routes.MapRoute(
                name: "DefaultWithCulture",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { culture = new CultureConstraint(defaultCulture: "en", pattern: "[a-z]{2}") });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { culture = "en", controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
