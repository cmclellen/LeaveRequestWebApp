﻿using System.Web.Optimization;

namespace CompanyABC.WebClient
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleScripts(bundles);
            BundleStyles(bundles);
#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }

        private static void BundleScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery",
                "//cdnjs.cloudflare.com/ajax/libs/jquery/1.10.2/jquery.min.js")
                .Include("~/scripts/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap",
                "//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.1/css/bootstrap.min.js")
                .Include("~/scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-core")
                .Include("~/scripts/angular-ui-router.js")
                .Include("~/app/app.js")
                .IncludeDirectory("~/app/controllers", "*.js"));

            bundles.Add(new ScriptBundle("~/bundles/misc")
                .Include("~/scripts/toastr.js"));
        }

        private static void BundleStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/bootstrap",
                "//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.1/css/bootstrap.min.css").Include(
                    "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/toastr.css",
                "~/Content/site.css"));
        }
    }
}
