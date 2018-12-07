using System.Web;
using System.Web.Optimization;

namespace AdlumenMVC.WebUI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap*"));

            bundles.Add(new ScriptBundle("~/bundles/gantt-chart").Include(
                "~/Scripts/gantt/angular-gantt.js",
                "~/Scripts/gantt/angular-gantt.min.js",
                "~/Scripts/gantt/angular-gantt-plugins.js",
                "~/Scripts/gantt/angular-gantt-plugins.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/raphael").Include(
                "~/Scripts/Raphael/raphael*",
                "~/Scripts/Raphael/angular-raphael-gauge.js"));

            bundles.Add(new ScriptBundle("~/bundles/jvectormap").Include(
                "~/Scripts/jvectormap/jquery-jvectormap.js",
                "~/Scripts/jvectormap/jquery-jvectormap-world-mill.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-calendar").Include(
                "~/Scripts/fullcalendar.js",
                "~/Scripts/fullcalendar.min.js",
                "~/Scripts/calendar/calendar.js"));

            bundles.Add(new ScriptBundle("~/bundles/nvd3").Include(
                //"~/Scripts/d3/d3.js",
                "~/Scripts/d3/d3.min.js",
                //"~/Scripts/nvd3-chart/nv.d3.js",
                "~/Scripts/nvd3-chart/nv.d3.min.js",
                //"~/Scripts/nvd3-chart/angular-nvd3.js",
                "~/Scripts/nvd3-chart/angular-nvd3.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                //"~/Scripts/angular.js",
                "~/Scripts/angular.min.js",
                "~/Scripts/lodash.js",
                "~/Scripts/Chart.min.js",
                "~/Scripts/angular-google-maps.js",
                "~/Scripts/angular-resource.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                "~/Scripts/angular-ui-tree.js",
                "~/Scripts/angular-chart.min.js",
                "~/Scripts/angular-ui-router.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-cookies.js",
                //"~/Scripts/angular-local-storage.js",
                "~/Scripts/angular-local-storage.min.js",
                "~/Scripts/underscore-min.js",
                //"~/Scripts/moment.js",
                "~/Scripts/moment.min.js",
                //"~/Scripts/angular-moment.js",
                "~/Scripts/angular-moment.min.js",
                "~/Scripts/restangular.js",
                "~/app/main.js",
                "~/app/config.js",
                "~/app/utils.js",
                "~/app/services/*.js",
                "~/app/controllers/*.js",
                "~/app/directives/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
                "~/Scripts/AdminLTE/app.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Site.css",
                //"~/Content/bootstrap/bootstrap.css",
                "~/Content/bootstrap/bootstrap.min.css",
                //"~/Content/font-awesome/css/font-awesome.css",
                "~/Content/font-awesome/css/font-awesome.min.css",
                "~/Content/AdminLTE/AdminLTE.css",
                "~/Content/AdminLTE/skins/_all-skins.css",
                "~/Content/angular-chart.css",
                "~/Content/angular-ui-tree.min.css",
                "~/Content/jvectormap/jquery-jvectormap-2.0.4.css",
                //"~/Content/angular-chart/angular-chart.css",
                "~/Content/angular-chart/angular-chart.min.css",
                "~/Content/gantt/angular-gantt.css",
                //"~/Content/fullcalendar.css",
                "~/Content/fullcalendar.min.css",
                "~/Content/nvd3-charts/nv.d3.min.css"
            ));

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
                        "~/Content/themes/base/jquery.ui.theme.css"));

        }
    }
}