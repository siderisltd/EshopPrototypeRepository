using System.Web.Optimization;

namespace Eshop.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Theme/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/theme-scripts").Include(
                        "~/Scripts/Theme/jquery-1.11.0.min.js",
                        "~/Scripts/Theme/jquery-migrate-1.2.1.min.js",
                        "~/Scripts/Theme/jquery.jpanelmenu.js",
                        "~/Scripts/Theme/jquery.themepunch.plugins.min.js",
                        "~/Scripts/Theme/jquery.themepunch.revolution.min.js",
                        "~/Scripts/Theme/jquery.themepunch.showbizpro.min.js",
                        "~/Scripts/Theme/jquery.magnific-popup.min.js",
                        "~/Scripts/Theme/hoverIntent.js",
                        "~/Scripts/Theme/superfish.js",
                        "~/Scripts/Theme/jquery.pureparallax.js",
                        "~/Scripts/Theme/jquery.pricefilter.js",
                        "~/Scripts/Theme/jquery.selectric.min.js",
                        "~/Scripts/Theme/jquery.royalslider.min.js",
                        "~/Scripts/Theme/SelectBox.js",
                        "~/Scripts/Theme/modernizr.custom.js",
                        "~/Scripts/Theme/waypoints.min.js",
                        "~/Scripts/Theme/jquery.flexslider-min.js",
                        "~/Scripts/Theme/jquery.counterup.min.js",
                        "~/Scripts/Theme/jquery.tooltips.min.js",
                        "~/Scripts/Theme/jquery.isotope.min.js",
                        "~/Scripts/Theme/puregrid.js",
                        "~/Scripts/Theme/stacktable.js",
                        "~/Scripts/Theme/custom.js",
                        "~/Scripts/Theme/switcher.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css").IncludeDirectory(
          "~/Content/Theme/colors", "*.css", true));

            bundles.Add(new StyleBundle("~/Content/theme-css").Include(
                      "~/Content/Theme/base.css",
                      "~/Content/Theme/font-awesome.css",
                    "~/Content/Theme/responsive.css",
                    "~/Content/Theme/style.css",
                    "~/Content/Theme/switcher.css"));
        }
    }
}
