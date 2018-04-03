// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="OhioTrackStats.com">
//   Copyright (c) 2017-2017 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Configures the application routing.
    /// </summary>
    public static class RouteConfig
    {
        /// <summary>
        /// Registers the routes to the route collection.
        /// </summary>
        /// <param name="routes">
        /// The incoming route collection.
        /// </param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
