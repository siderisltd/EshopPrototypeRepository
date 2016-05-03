namespace Eshop.Web
{
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Infrastructure.Mapping;
    using Ninject;
    using Services.Data.Contracts;

    public class MvcApplication : HttpApplication
    {
        [Inject]
        public IUsersService usersService;

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            HttpContextBase currentContext = new HttpContextWrapper(context);
            RouteData routeData = RouteTable.Routes.GetRouteData(currentContext);

            var culture = routeData.Values["culture"] as string;
            switch (culture.ToLower())
            {
                case "bg": return "bg";
                case "en": return "en";
                default:
                    return "en";
            }
        }

        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            DbConfig.Initialize();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());
        }
    }
}
