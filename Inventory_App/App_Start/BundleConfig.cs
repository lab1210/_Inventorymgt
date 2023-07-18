using System.Web;
using System.Web.Optimization;

namespace Inventory_App
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/js/jquery-3.6.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Feather").Include(
                      "~/Scripts/js/feather.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/slimscroll").Include(
                      "~/Scripts/js/jquery.slimscroll.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryDataTables").Include(
                      "~/Scripts/js/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTablesBootstrap").Include(
                      "~/Scripts/js/dataTables.bootstrap4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap5").Include(
                      "~/Scripts/bootstrap.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/apexchart").Include(
                      "~/Content/plugins/apexchart/apexcharts.min.js",
                      "~/Content/plugins/apexchart/chart-data.js"));
            bundles.Add(new ScriptBundle("~/bundles/owl").Include(
                "~/Content/plugins/owlcarousel/owl.carousel.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/select").Include(
                     "~/Content/plugins/select2/js/select2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                    "~/Scripts/js/moment.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/datetime").Include(
                    "~/Scripts/js/bootstrap-datetimepicker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/sweetalert").Include(
                    "~/Content/plugins/sweetalert/sweetalert2.all.min.js",
                    "~/Content/plugins/sweetalert/sweetalerts.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                     "~/Scripts/js/script.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/css/bootstrap-datetimepicker.min.css",
                      "~/Content/css/animate.css",
                      "~/Content/css/dataTables.bootstrap4.min.css",
                      "~/Content/css/style.css"));
            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                      "~/Content/plugins/fontawesome/css/fontawesome.min.css",
                      "~/Content/plugins/fontawesome/css/all.min.css"));
        }
    }
}
