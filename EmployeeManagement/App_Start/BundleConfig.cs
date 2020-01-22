using System.Web;
using System.Web.Optimization;

namespace EmployeeManagement
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(               
                     "~/Content/bootstrap-lumen.css",
                     "~/Content/DataTables/css/dataTables.bootstrap.css",
                     "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/javascript").Include(
                "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/datatables.bootstrap.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));           
        }
    }
}
