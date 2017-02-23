using System.Web.Optimization;

namespace Valtech.Sandbox.Website
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
	        Bundle styleBundle = new StyleBundle("~/master/styles")
									.Include("~/Content/bootstrap.min.css");

			bundles.Add(styleBundle);
        }
    }
}