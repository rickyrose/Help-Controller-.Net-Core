using System.Web;
using System.Web.Optimization;

namespace RickyRose
{
    public class BundleConfig
    [
        //CHECK MICROSOFT FOR MORE INFO
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/CoreAoo").Include("~/assets/pluguns/excanvas.min.js", "~/assets/plugins/respond.min.js"));
        }
    ]
}