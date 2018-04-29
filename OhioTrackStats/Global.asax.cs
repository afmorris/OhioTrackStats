// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="OhioTrackStats.com">
//   Copyright (c) 2017-2017 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using OhioTrackStats.Grammar.Models;

namespace OhioTrackStats
{
    using System.Drawing;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Autofac;
    using Autofac.Integration.Mvc;

    using OhioTrackStats.Constants;
    using OhioTrackStats.DataModels.Converters;
    using OhioTrackStats.Models;

    using ServiceStack.Configuration;
    using ServiceStack.Data;
    using ServiceStack.OrmLite;

    using DatabaseColorConverter = OhioTrackStats.DataModels.Converters.ColorConverter;

    /// <summary>
    /// The application entry point.
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        public static Dictionary<string, HashSet<string>> SchoolLookup { get; set; } = new Dictionary<string, HashSet<string>>();
        public static IList<Event> GrammarEvents { get; set; } = new List<Event>();

        /// <summary>
        /// Executes when the application starts up. Used to setup the application.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SqlServer2014Dialect.Provider.RegisterConverter<Gender>(new GenderConverter());
            SqlServer2014Dialect.Provider.RegisterConverter<TimingMethod>(new TimingMethodConverter());
            SqlServer2014Dialect.Provider.RegisterConverter<Color>(new DatabaseColorConverter());
            SqlServer2014Dialect.Provider.RegisterConverter<PerformanceData>(new PerformanceDataConverter());

            var builder = new ContainerBuilder();
            builder.Register(x => new OrmLiteConnectionFactory(ConfigUtils.GetConnectionString("OhioTrackStats"), SqlServer2014Dialect.Provider)).As<IDbConnectionFactory>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static void ResetUploadData()
        {
            SchoolLookup = new Dictionary<string, HashSet<string>>();
            GrammarEvents = new List<Event>();
        }
    }
}
