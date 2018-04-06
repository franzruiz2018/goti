using System.Web;
using System.Web.Optimization;

namespace GOTIV2
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, consulte http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/AdminLTE.css",
                      "~/Content/AdminLTE.min.css",
                      "~/Content/site.css"));


            bundles.Add(new ScriptBundle("~/bundles/highcharts").Include(
                   "~/Scripts/highcharts.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootbox.min").Include(
                  "~/Scripts/bootbox.min.js"));






         
         
        }
    }
}
