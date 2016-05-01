using System.Web.Optimization;

namespace Bookva.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vendor")
                .Include("~/www/js/angular.min.js")
                .Include("~/www/js/angular-cookies.min.js")
                .Include("~/www/js/ui-bootstrap-tpls.min.js")
                .Include("~/www/js/angular-route.min.js")
                .Include("~/www/js/angular-sanitize.min.js")
                .Include("~/www/js/jquery-2.1.3.min.js")
                //.IncludeDirectory("~/www/app", "*.js", true)
                );
            bundles.Add(new ScriptBundle("~/bundles/app")
                //.Include("~/www/app/mainController.js")
                .IncludeDirectory("~/www/app", "*.js", true));
                //.IncludeDirectory("~/www/js", "*.js", true));
                
            bundles.Add(new StyleBundle("~/bundles/css")
                .IncludeDirectory("~/www/css", "*.css", true));

        }
    }
}
