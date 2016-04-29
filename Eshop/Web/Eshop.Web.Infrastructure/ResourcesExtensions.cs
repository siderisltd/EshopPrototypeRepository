namespace Eshop.Web.Infrastructure
{
    using System;
    using System.Reflection;
    using System.Resources;
    using GlobalConstants;

    public static class ResourcesExtensions
    {

        public static string GetCategoryResourceByName(this string name)
        {
            Assembly assembly = Assembly.Load(AssembliesConstants.GLOBAL_RESOURCES_ASSEMBLY);
            ResourceManager rm = new ResourceManager(AssembliesConstants.CATEGORIES_RESOURCES_ASSEMBLY, assembly);
            rm.IgnoreCase = true;
            var resource = rm.GetString(name) ?? name;

            return resource;
        }
    }
}
