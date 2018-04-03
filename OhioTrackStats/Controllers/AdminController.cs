// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminController.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OhioTrackStats.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using OhioTrackStats.DataModels;
    using OhioTrackStats.ViewModels.Admin;

    using ServiceStack.Data;
    using ServiceStack.OrmLite;

    [RoutePrefix("admin")]
    public class AdminController : Controller
    {
        private readonly IDbConnectionFactory databaseFactory;

        public AdminController(IDbConnectionFactory databaseFactory) => this.databaseFactory = databaseFactory;

        [Route("bulk")]
        public ActionResult Bulk()
        {
            var vm = new BulkViewModel();

            using (var db = this.databaseFactory.Open())
            {
                var events = db.Select<TrackAndFieldEvent>().OrderBy(x => x.Order).ToList();
                vm.Events = events;
            }

            return this.View(vm);
        }

        public ActionResult AthleteEntry()
        {
            var vm = new AthleteEntryViewModel();

            using (var db = this.databaseFactory.Open())
            {
                var schools = db.Select<School>().ToList();
                vm.Schools = schools;
            }

            return this.View(vm);
        }
    }
}