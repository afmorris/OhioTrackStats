// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="OhioTrackStats.com">
//   Copyright (c) 2017-2017 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats
{
    using System.Web.Mvc;

    /// <summary>
    ///  Configures the application filters.
    /// </summary>
    public static class FilterConfig
    {
        /// <summary>
        /// Registers the filters to the global filter collection.
        /// </summary>
        /// <param name="filters">
        /// The filters to get added.
        /// </param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
