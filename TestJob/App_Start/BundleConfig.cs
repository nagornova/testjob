using System.Web;
using System.Web.Optimization;

namespace TestJob
{
    public class BundleConfig
    {
        // Дополнительные сведения о Bundling см. по адресу http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Default by MVC application
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-{version}.js"));

            // Default by MVC application
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                          "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                          "~/Scripts/bootstrap.js",
                          "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                          "~/Scripts/bootstrap-datepicker.js",
                          "~/Scripts/daterangepicker.js",
                          "~/Scripts/bootstrap-slider.js"
                          ));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                             "~/Scripts/angular.js",
                             "~/Scripts/angular-route.js",
                             "~/Scripts/angular-ui-router.js",
                             "~/Scripts/angular-sanitizer.js",
                             "~/Scripts/ng-grid.js",
                             "~/Scripts/ng-grid-flexible-height.js",
                             "~/Scripts/moment.js"
                             ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                                "~/Content/site.css",
                                "~/Content/bootstrap.css",
                                "~/Content/bootstrap-theme.css",
                                "~/Content/bootstrap-datepicker.css",
                                "~/Content/daterangepicker - bs3.css",
                                "~/Content/slider.css"));

            // Default by MVC application
            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                                "~/Content/themes/base/jquery.ui.core.css",
                                "~/Content/themes/base/jquery.ui.resizable.css",
                                "~/Content/themes/base/jquery.ui.selectable.css",
                                "~/Content/themes/base/jquery.ui.accordion.css",
                                "~/Content/themes/base/jquery.ui.autocomplete.css",
                                "~/Content/themes/base/jquery.ui.button.css",
                                "~/Content/themes/base/jquery.ui.dialog.css",
                                "~/Content/themes/base/jquery.ui.slider.css",
                                "~/Content/themes/base/jquery.ui.tabs.css",
                                "~/Content/themes/base/jquery.ui.datepicker.css",
                                "~/Content/themes/base/jquery.ui.progressbar.css",
                                "~/Content/themes/base/jquery.ui.theme.css",
                                "~/Content/ng-grid.css"
                                ));

            // our controller, services, directives and main app js files
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                          "~/app/app.js",
                          "~/app/controllers/address.js",
                          "~/app/services/address.js"
                          ));
        }
    }
}