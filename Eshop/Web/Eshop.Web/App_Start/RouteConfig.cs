using System.Web.Mvc;
using System.Web.Routing;

namespace Eshop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SearchByCategory",
                url: "Items/ByCategory/{name}",
                defaults: new { controller = "Items", action = "ByCategory" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
