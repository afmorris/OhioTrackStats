// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="OhioTrackStats.com">
//   Copyright (c) 2017-2017 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats
{
    using System.Web.Optimization;

    /// <summary>
    /// Configures the application bundles for styles and scripts.
    /// </summary>
    public static class BundleConfig
    {
        /// <summary>
        /// Registers bundles to the incoming bundle collection.
        /// </summary>
        /// <param name="bundles">
        /// The incoming bundle collection.
        /// </param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/bootstrap").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/popper.js",
                "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/js/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/css/site").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/css/cover").Include(
                "~/Content/bootstrap.css",
                "~/Content/cover.css"));

            bundles.Add(new ScriptBundle("~/js/submit").Include(
                "~/Scripts/submit.js"));
        }
    }
}
