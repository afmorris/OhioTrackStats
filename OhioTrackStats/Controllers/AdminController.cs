// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminController.cs" company="OhioTrackStats.com">
//   Copyright (c) 2018-2018 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Antlr4.Runtime;
using Newtonsoft.Json;
using OhioTrackStats.Constants;
using OhioTrackStats.Grammar.Listeners;
using OhioTrackStats.Grammar.Models;
using ServiceStack;

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

        [Route("")]
        public ActionResult Index()
        {
            return this.View();
        }

        [Route("upload")]
        public ActionResult Upload()
        {
            var vm = new UploadFileViewModel();

            using (var db = this.databaseFactory.Open())
            {
                vm.Schools = db.Select<School>().Where(x => !x.OhsaaTournamentName.IsNullOrEmpty()).OrderBy(x => x.OhsaaTournamentName).ToList();
            }

            return this.View(vm);
        }

        [Route("upload-review")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadReview(UploadFileViewModel viewModel)
        {
            var vm = new UploadReviewViewModel();
            viewModel.MeetDate = new DateTimeOffset(viewModel.MeetDate.Date, TimeSpan.Zero);

            try
            {
                string data;
                using (var streamReader = new StreamReader(Request.Files[0]?.InputStream ?? throw new InvalidOperationException()))
                {
                    data = streamReader.ReadToEnd();
                }

                var schoolTranslations = viewModel.SchoolTranslation.Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                var lookup = new Dictionary<string, HashSet<string>>();
                foreach (var translation in schoolTranslations)
                {
                    var split = translation.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    var namesInFile = split[0].Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                    var lookupName = split[1];

                    lookup.Add(lookupName, new HashSet<string>(namesInFile.Select(x => x)));
                }

                MvcApplication.ResetUploadData();
                MvcApplication.SchoolLookup = lookup;

                AntlrInputStream inputStream = new AntlrInputStream(data);
                HyTekLexer lexer = new HyTekLexer(inputStream);
                CommonTokenStream tokenStream = new CommonTokenStream(lexer);
                HyTekParser parser = new HyTekParser(tokenStream);
                parser.AddParseListener(new EventListener());
                parser.init();

                var schools = MvcApplication.SchoolLookup;
                var grammarEvents = MvcApplication.GrammarEvents;

                //PopulateViewModel(vm, )

                MvcApplication.ResetUploadData();
            }
            catch (Exception ex)
            {
                vm.Error = ex.ToString();
            }

            return this.View(vm);
        }

        [Route("athlete")]
        [HttpGet]
        public ActionResult AthleteEntry()
        {
            var vm = new AthleteEntryViewModel();

            using (var db = this.databaseFactory.Open())
            {
                var schools = db.LoadSelect<School>().OrderBy(x => x.Name).ToList();
                vm.Schools = schools;
            }

            return this.View(vm);
        }

        [Route("athlete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AthleteEntry(AthleteEntryViewModel viewModel)
        {
            using (var db = this.databaseFactory.Open())
            {
                db.Insert(new Athlete
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Gender = new Gender(viewModel.Gender),
                    GraduationYear = viewModel.GraduationYear,
                    SchoolId = viewModel.SelectedSchoolId
                });
            }

            return this.RedirectToAction("AthleteEntry");
        }

        [Route("location")]
        [HttpGet]
        public ActionResult LocationEntry()
        {
            var vm = new LocationEntryViewModel();
            return this.View(vm);
        }

        [Route("location")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LocationEntry(LocationEntryViewModel viewModel)
        {
            using (var db = this.databaseFactory.Open())
            {
                db.Insert(new Location
                {
                    Address1 = viewModel.Address1,
                    Address2 = viewModel.Address2,
                    City = viewModel.City,
                    State = viewModel.State,
                    Zip = viewModel.Zip
                });
            }

            return this.RedirectToAction("LocationEntry");
        }

        [Route("meet")]
        [HttpGet]
        public ActionResult MeetEntry()
        {
            var vm = new MeetEntryViewModel();

            using (var db = this.databaseFactory.Open())
            {
                vm.Locations = db.LoadSelect<Location>().OrderBy(x => x.City).ToList();
                vm.Meets = db.LoadSelect<Meet>().OrderBy(x => x.Date).ThenBy(x => x.Name).ToList();
            }

            return this.View(vm);
        }

        [Route("meet")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MeetEntry(MeetEntryViewModel viewModel)
        {
            using (var db = this.databaseFactory.Open())
            {
                db.Insert(new Meet
                {
                    LocationId = viewModel.SelectedLocationId,
                    Name = viewModel.Name,
                    Date = viewModel.Date
                });
            }

            return this.RedirectToAction("MeetEntry");
        }

        [Route("performance")]
        [HttpGet]
        public ActionResult PerformanceEntry()
        {
            var vm = new PerformanceEntryViewModel();

            using (var db = this.databaseFactory.Open())
            {
                vm.Schools = db.LoadSelect<School>().OrderBy(x => x.OhsaaTournamentName).ToList();
                vm.Events = db.LoadSelect<TrackAndFieldEvent>().OrderBy(x => x.Order).ToList();
                vm.Meets = db.LoadSelect<Meet>().OrderBy(x => x.Date).ThenBy(x => x.Name).ToList();
            }

            return this.View(vm);
        }

        [Route("performance")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PerformanceEntry(PerformanceEntryViewModel viewModel)
        {
            using (var db = this.databaseFactory.Open())
            {
                db.Insert(new Performance
                {
                    EventId = viewModel.SelectedEventId,
                    SchoolId = viewModel.SelectedSchoolId,
                    MeetId = viewModel.SelectedMeetId,
                    Data = viewModel.Data,
                    Date = viewModel.Date,
                    TimingMethod = new TimingMethod(viewModel.TimingMethod),
                    Notes = viewModel.Notes
                });
            }

            return this.RedirectToAction("PerformanceEntry");
        }

        [HttpGet]
        public ActionResult AssociateAthletePerformance()
        {
            var vm = new AssociateAthletePerformanceViewModel();

            using (var db = this.databaseFactory.Open())
            {
                vm.Athletes = db.LoadSelect<Athlete>().OrderBy(x => x.GraduationYear).ThenBy(x => x.LastName).ThenBy(x => x.SchoolId).ToList();
                vm.Performances = db.LoadSelect<Performance>(x => x.NeedsAssociated).OrderBy(x => x.InsertedDate).ToList();
            }

            return this.View(vm);
        }

        public ActionResult AssociateAthletePerformance(AssociateAthletePerformanceViewModel viewModel)
        {
            using (var db = this.databaseFactory.Open())
            {
                var performance = db.LoadSingleById<Performance>(viewModel.SelectedPerformanceId);
                if (performance.Event.IsRelayEvent)
                {
                    var count = db.Count<AthletePerformance>(x => x.PerformanceId == viewModel.SelectedPerformanceId);
                    if (count == 3)
                    {
                        db.UpdateOnly(() => new Performance { NeedsAssociated = false }, p => p.Id == viewModel.SelectedPerformanceId);
                    }
                }
                else
                {
                    db.UpdateOnly(() => new Performance { NeedsAssociated = false }, p => p.Id == viewModel.SelectedPerformanceId);
                }

                db.Insert(new AthletePerformance
                {
                    AthleteId = viewModel.SelectedAthleteId,
                    PerformanceId = viewModel.SelectedPerformanceId
                });
            }

            return this.RedirectToAction("AssociateAthletePerformance");
        }

        [Route("GetAthletes/{schoolId:guid}")]
        public ContentResult GetAthletes(Guid schoolId)
        {
            using (var db = this.databaseFactory.Open())
            {
                var athletes = db.Select<Athlete>(x => x.SchoolId == schoolId).OrderBy(x => x.GraduationYear).ThenBy(x => x.LastName).ToList();
                return Content(JsonConvert.SerializeObject(athletes), "application/json");
            }
        }
    }
}