// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="OhioTrackStats.com">
//   Copyright (c) 2017-2017 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using OhioTrackStats.Constants;
    using OhioTrackStats.DataModels;
    using OhioTrackStats.Models;
    using OhioTrackStats.ViewModels;

    using ServiceStack.Data;
    using ServiceStack.OrmLite;
    using ServiceStack.OrmLite.Dapper;

    /// <summary>
    /// The main application controller.
    /// </summary>
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        /// <summary>
        /// The injected database factory.
        /// </summary>
        private readonly IDbConnectionFactory databaseFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="databaseFactory">
        /// The injected database factory.
        /// </param>
        public HomeController(IDbConnectionFactory databaseFactory) => this.databaseFactory = databaseFactory;

        /// <summary>
        /// The Index page.
        /// </summary>
        /// <returns>
        /// The view that represents the index page.
        /// </returns>
        [Route("")]
        public ActionResult Index() => this.View();

        /// <summary>
        /// The Leaderboard page.
        /// </summary>
        /// <returns>
        /// The view that represents the leaderboard page.
        /// </returns>
        [Route("leaderboard")]
        public ActionResult Leaderboard()
        {
            IList<TrackAndFieldEvent> maleEvents;
            IList<TrackAndFieldEvent> femaleEvents;

            using (var db = this.databaseFactory.Open())
            {
                maleEvents = db.Select<TrackAndFieldEvent>(x => x.Gender == Gender.Male).OrderBy(x => x.Order).ToList();
                femaleEvents = db.Select<TrackAndFieldEvent>(x => x.Gender == Gender.Female).OrderBy(x => x.Order).ToList();
            }

            var vm = new LeaderboardViewModel
            {
                MaleEvents = maleEvents,
                FemaleEvents = femaleEvents
            };

            return this.View(vm);
        }

        /// <summary>
        /// The Event page.
        /// </summary>
        /// <param name="name">
        /// The event's name
        /// </param>
        /// <param name="gender">
        /// The event's gender.
        /// </param>
        /// <returns>
        /// The view that represents the event page.
        /// </returns>
        [Route("event/{name}/{gender}")]
        public ActionResult Event(string name, string gender)
        {
            var vm = new EventViewModel();

            using (var db = this.databaseFactory.Open())
            {
                var @event = db.Single<TrackAndFieldEvent>(x => x.SafeName == name && x.Gender == gender);
                if (@event == null)
                {
                    return this.RedirectToAction(nameof(this.Error404));
                }

                vm.Event = @event;
                var performances = db.SqlList<PerformanceView>("EXEC GetEventLeaderboard @EventId", new { EventId = @event.Id });
                foreach (var performance in performances)
                {
                    performance.PerformanceData = PerformanceData.FromData(performance.Data, @event);
                }

                var divisions = db.Select<Division>().OrderBy(x => x.Order);
                foreach (var division in divisions)
                {
                    vm.EventDivisions.Add(new EventDivisionViewModel { Division = division.Name, Performances = performances.Where(x => x.Division == division.Name).ToList() });
                }
            }

            return this.View(vm);
        }

        /// <summary>
        /// The Submit page.
        /// </summary>
        /// <returns>
        /// The view that represents the submit performance page.
        /// </returns>
        [Route("submit")]
        public ActionResult Submit() => this.View();

        /// <summary>
        /// The Privacy Policy page.
        /// </summary>
        /// <returns>
        /// The view that represents the privacy policy page.
        /// </returns>
        [Route("privacy-policy")]
        public ActionResult Privacy() => this.View();

        /// <summary>
        /// The Terms of Use page.
        /// </summary>
        /// <returns>
        /// The view that represents the terms of use page.
        /// </returns>
        [Route("terms-of-use")]
        public ActionResult Terms() => this.View();

        /// <summary>
        /// The 404 Error Page
        /// </summary>
        /// <returns>
        /// The view that represents the Error 404 page
        /// </returns>
        [Route("not-found")]
        public ActionResult Error404() => this.View();
    }
}