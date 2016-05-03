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
            switch (culture)
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

        //protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        //{
        //    if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
        //    {
        //        if (HttpContext.Current.Session == null)
        //        {
        //            return;
        //        }

        //        var sessionCulture = HttpContext.Current.Session["cultureInfo"];
        //        CultureInfo cultureToSet = CultureInfo.GetCultureInfo("en");

        //        if (sessionCulture == null)
        //        {
        //            if (this.User.Identity.IsAuthenticated)
        //            {
        //                var usService = new UsersService(new GenericRepository<User>(new EshopDbContext()));
        //                var userId = this.User.Identity.GetUserId();
        //                var userCulture = usService.GetUserCulture(userId);
        //                if (!string.IsNullOrEmpty(userCulture))
        //                {
        //                    var usersCulture = CultureInfo.GetCultureInfo(userCulture);
        //                    HttpContext.Current.Session["cultureInfo"] = usersCulture;
        //                    sessionCulture = usersCulture;
        //                    cultureToSet = sessionCulture as CultureInfo;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            cultureToSet = CultureInfo.GetCultureInfo(sessionCulture.ToString());
        //        }


        //        Thread.CurrentThread.CurrentCulture = cultureToSet;
        //        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

        //        return;
        //    }
        //}
    }
}
