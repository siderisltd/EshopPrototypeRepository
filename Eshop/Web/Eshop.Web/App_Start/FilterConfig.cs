namespace Eshop.Web
{
    using System.Web.Mvc;
    using Helpers.Filters;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CultureFilter(defaultCulture: "en"));
            filters.Add(new HandleErrorAttribute());
        }
    }
}
