using System;
using System.Collections.Generic;
using System.Linq;
using OhioTrackStats.Grammar.Models;
using Performance = OhioTrackStats.Grammar.Models.Performance;

namespace OhioTrackStats.Grammar.Listeners
{
    public class EventListener : HyTekBaseListener
    {
        private readonly HashSet<string> _noPerformance = new HashSet<string> { "FS", "NH", "DQ", "FOUL", "NT", "DNF", "DQInterference", "SCR", "ND" };

        public override void ExitEvent(HyTekParser.EventContext context)
        {
            var @event = new Event();

            @event.EventInfo.Gender = context.eventInfo().eventGender().GetText();
            @event.EventInfo.Name = context.eventInfo().eventName().GetText();

            //@event.EventHeader = context.eventHeader().GetText();

            foreach (var eventResult in context.eventResult())
            {
                if (eventResult.individualResult() != null)
                {
                    var individualContext = eventResult.individualResult();
                    if (_noPerformance.Any(individualContext.performance().GetText().Contains))
                    {
                        continue;
                    }

                    var result = new IndividualResult();
                    int.TryParse(individualContext.place().GetText(), out var place);
                    result.Place = place;

                    var athleteNameTokenGroups = individualContext.athleteName().words();
                    var athleteNameList = new List<string>();
                    foreach (var tokenGroup in athleteNameTokenGroups)
                    {
                        if (tokenGroup?.children != null)
                        {
                            foreach (var child in tokenGroup.children)
                            {
                                athleteNameList.Add(child.GetText());
                            }
                        }
                    }

                    result.AthleteName = string.Join(" ", athleteNameList);

                    //result.AthleteName = string.Join(" ", individualContext.athleteName().words().children);

                    foreach (var kvp in MvcApplication.SchoolLookup)
                    {
                        foreach (var schoolName in kvp.Value)
                        {
                            if (result.AthleteName.Contains(schoolName))
                            {
                                result.SchoolName = schoolName;
                                result.AthleteName = result.AthleteName.Replace($" {schoolName}", "");
                            }
                        }
                    }

                    if (individualContext.athleteYear() != null)
                    {
                        int.TryParse(individualContext.athleteYear().GetText(), out var athleteYear);
                        result.AthleteYear = athleteYear;
                    }

                    if (string.IsNullOrEmpty(result.SchoolName))
                    {
                        result.SchoolName = string.Join(" ", individualContext.schoolName().words().children);
                    }

                    if (individualContext.seed() != null)
                    {
                        result.Seed = new Performance();
                        if (individualContext.seed().time() != null)
                        {
                            float seedMinutes = 0;
                            if (individualContext.seed().time().minute() != null)
                            {
                                float.TryParse(individualContext.seed().time().minute().GetText(), out seedMinutes);
                            }

                            float.TryParse(individualContext.seed().time().second().GetText(), out var seedSeconds);
                            float.TryParse(individualContext.seed().time().@decimal().GetText(), out var seedDecimal);

                            var seedData = (seedMinutes * 60) + seedSeconds + (seedDecimal / 100);
                            result.Seed.Data = Math.Round(seedData, 2);
                        }
                        else if (individualContext.seed().distance() != null)
                        {
                            float.TryParse(individualContext.seed().distance().foot().GetText(), out var seedFeet);
                            float.TryParse(individualContext.seed().distance().inch().GetText(), out var seedInches);
                            float seedDecimal = 0;
                            if (individualContext.seed().distance().@decimal() != null)
                            {
                                float.TryParse(individualContext.seed().distance().@decimal().GetText(), out seedDecimal);
                            }

                            var seedData = (seedFeet * 12) + seedInches + (seedDecimal / 100);
                            result.Seed.Data = Math.Round(seedData, 2);
                        }
                    }

                    result.Performance = new Performance();
                    if (individualContext.performance().time() != null)
                    {
                        float performanceMinutes = 0;
                        if (individualContext.performance().time().minute() != null)
                        {
                            float.TryParse(individualContext.performance().time().minute().GetText(), out performanceMinutes);
                        }
                        float.TryParse(individualContext.performance().time().second().GetText(), out var performanceSeconds);
                        float.TryParse(individualContext.performance().time().@decimal().GetText(), out var performanceDecimal);

                        var performanceData = (performanceMinutes * 60) + performanceSeconds + (performanceDecimal / 100);
                        SanityCheck(performanceData, @event.EventInfo.Name, @event.EventInfo.Gender);
                        result.Performance.Data = Math.Round(performanceData, 2);
                    }
                    else if (individualContext.performance().distance() != null)
                    {
                        float.TryParse(individualContext.performance().distance().foot().GetText(), out var performanceFeet);
                        float.TryParse(individualContext.performance().distance().inch().GetText(), out var performanceInches);
                        float performanceDecimal = 0;
                        if (individualContext.performance().distance().@decimal() != null)
                        {
                            float.TryParse(individualContext.performance().distance().@decimal().GetText(), out performanceDecimal);
                        }

                        var performanceData = (performanceFeet * 12) + performanceInches + (performanceDecimal / 100);
                        SanityCheck(performanceData, @event.EventInfo.Name, @event.EventInfo.Gender);
                        result.Performance.Data = Math.Round(performanceData, 2);
                    }

                    if (individualContext.heatNumber() != null)
                    {
                        int.TryParse(individualContext.heatNumber().GetText(), out var heatNumber);
                        result.HeatNumber = heatNumber;
                    }

                    if (individualContext.points() != null)
                    {
                        int.TryParse(individualContext.points().GetText(), out var points);
                        result.Points = points;
                    }

                    if (individualContext.tiebreaker() != null)
                    {
                        result.Tiebreaker = new Performance();
                        if (individualContext.tiebreaker().time() != null)
                        {
                            float tiebreakerMinutes = 0;
                            if (individualContext.tiebreaker().time().minute() != null)
                            {
                                float.TryParse(individualContext.tiebreaker().time().minute().GetText(), out tiebreakerMinutes);
                            }
                            float.TryParse(individualContext.tiebreaker().time().second().GetText(), out var tiebreakerSeconds);
                            float.TryParse(individualContext.tiebreaker().time().@decimal().GetText(), out var tiebreakerDecimal);

                            var tiebreakerData = (tiebreakerMinutes * 60) + tiebreakerSeconds + (tiebreakerDecimal / 100);
                            result.Tiebreaker.Data = Math.Round(tiebreakerData, 2);
                        }
                        else if (individualContext.tiebreaker().distance() != null)
                        {
                            float.TryParse(individualContext.tiebreaker().distance().foot().GetText(), out var tiebreakerFeet);
                            float.TryParse(individualContext.tiebreaker().distance().inch().GetText(), out var tiebreakerInches);
                            float tiebreakerDecimal = 0;
                            if (individualContext.tiebreaker().distance().@decimal() != null)
                            {
                                float.TryParse(individualContext.tiebreaker().distance().@decimal().GetText(), out tiebreakerDecimal);
                            }

                            var tiebreakerData = (tiebreakerFeet * 12) + tiebreakerInches + (tiebreakerDecimal / 100);
                            result.Tiebreaker.Data = Math.Round(tiebreakerData, 2);
                        }
                    }

                    @event.EventResults.Add(result);
                }
                else if (eventResult.relayResult() != null)
                {
                    var relayContext = eventResult.relayResult();

                    if (_noPerformance.Any(relayContext.performance().GetText().Contains))
                    {
                        continue;
                    }

                    var result = new RelayResult();
                    int.TryParse(relayContext.place().GetText(), out var place);
                    result.Place = place;
                    result.SchoolName = string.Join(" ", relayContext.schoolName().words().children);
                    if (relayContext.seed() != null)
                    {
                        result.Seed = new Performance();
                        float seedMinutes = 0;
                        if (relayContext.seed().time().minute() != null)
                        {
                            float.TryParse(relayContext.seed().time().minute().GetText(), out seedMinutes);
                        }
                        float.TryParse(relayContext.seed().time().second().GetText(), out var seedSeconds);
                        float.TryParse(relayContext.seed().time().@decimal().GetText(), out var seedDecimal);

                        var seedData = (seedMinutes * 60) + seedSeconds + (seedDecimal / 100);
                        result.Seed.Data = Math.Round(seedData, 2);
                    }

                    result.Performance = new Performance();
                    float performanceMinutes = 0;
                    if (relayContext.performance().time().minute() != null)
                    {
                        float.TryParse(relayContext.performance().time().minute().GetText(), out performanceMinutes);
                    }
                    float.TryParse(relayContext.performance().time().second().GetText(), out var performanceSeconds);
                    float.TryParse(relayContext.performance().time().@decimal().GetText(), out var performanceDecimal);

                    var performanceData = (performanceMinutes * 60) + performanceSeconds + (performanceDecimal / 100);
                    SanityCheck(performanceData, @event.EventInfo.Name, @event.EventInfo.Gender);
                    result.Performance.Data = Math.Round(performanceData, 2);

                    if (relayContext.heatNumber() != null)
                    {
                        int.TryParse(relayContext.heatNumber().GetText(), out var heatNumber);
                        result.HeatNumber = heatNumber;
                    }

                    if (relayContext.points() != null)
                    {
                        int.TryParse(relayContext.points().GetText(), out var points);
                        result.Points = points;
                    }

                    if (relayContext.tiebreaker() != null)
                    {
                        result.Tiebreaker = new Performance();
                        float tiebreakerMinutes = 0;
                        if (relayContext.tiebreaker().time().minute() != null)
                        {
                            float.TryParse(relayContext.tiebreaker().time().minute().GetText(), out tiebreakerMinutes);
                        }
                        float.TryParse(relayContext.tiebreaker().time().second().GetText(), out var tiebreakerSeconds);
                        float.TryParse(relayContext.tiebreaker().time().@decimal().GetText(), out var tiebreakerDecimal);

                        var tiebreakerData = (tiebreakerMinutes * 60) + tiebreakerSeconds + (tiebreakerDecimal / 100);
                        result.Tiebreaker.Data = Math.Round(tiebreakerData, 2);
                    }

                    if (relayContext.legInfo() != null)
                    {
                        result.LegInfo = new LegInfo();

                        foreach (var legContext in relayContext.legInfo().leg())
                        {
                            var leg = new Leg();

                            int.TryParse(legContext.legNumber().GetText(), out int legNumber);
                            leg.Number = legNumber;

                            var athleteNameTokenGroups = legContext.athleteName().words();
                            var athleteNameList = new List<string>();
                            foreach (var tokenGroup in athleteNameTokenGroups)
                            {
                                if (tokenGroup?.children != null)
                                {
                                    foreach (var child in tokenGroup.children)
                                    {
                                        athleteNameList.Add(child.GetText());
                                    }
                                }
                            }

                            leg.AthleteName = string.Join(" ", athleteNameList);

                            //leg.AthleteName = string.Join(" ", legContext.athleteName().words().children);

                            if (legContext.athleteYear() != null)
                            {
                                int.TryParse(legContext.athleteYear().GetText(), out var athleteYear);
                                leg.AthleteYear = athleteYear;
                            }

                            result.LegInfo.Legs.Add(leg);
                        }
                    }

                    @event.EventResults.Add(result);
                }
            }

            MvcApplication.GrammarEvents.Add(@event);

            base.ExitEvent(context);
        }

        private void SanityCheck(double data, string eventName, string eventGender)
        {
            if (eventGender == "Boys")
            {
                switch (eventName)
                {
                    case "100MeterDash":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 10, null);
                        break;
                    case "200MeterDash":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 20, null);
                        break;
                    case "400MeterDash":
                    case "400MeterDashTimedFinal":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 45, null);
                        break;
                    case "800MeterRun":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 107, null);
                        break;
                    case "1600MeterRun":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 240, null);
                        break;
                    case "3200MeterRun":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 510, null);
                        break;
                    case "110MeterHurdles39\"":
                    case "110MeterHurdles":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 13, null);
                        break;
                    case "300MeterHurdles36\"":
                    case "300MeterHurdles":
                    case "300MeterHurdlesTimedFinal":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 35, null);
                        break;
                    case "4x100MeterRelay":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 40, null);
                        break;
                    case "4x200MeterRelay":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 80, null);
                        break;
                    case "4x400MeterRelay":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 195, null);
                        break;
                    case "4x800MeterRelay":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 455, null);
                        break;
                    case "ShotPut":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 60, 840);
                        break;
                    case "DiscusThrow":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 60, 2400);
                        break;
                    case "HighJump":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 30, 90);
                        break;
                    case "LongJump":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 30, 300);
                        break;
                    case "PoleVault":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 30, 216);
                        break;
                    default:
                        break;
                }
            }
            else if (eventGender == "Girls")
            {
                switch (eventName)
                {
                    case "100MeterDash":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 10, null);
                        break;
                    case "200MeterDash":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 20, null);
                        break;
                    case "400MeterDash":
                    case "400MeterDashTimedFinal":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 45, null);
                        break;
                    case "800MeterRun":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 107, null);
                        break;
                    case "1600MeterRun":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 240, null);
                        break;
                    case "3200MeterRun":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 510, null);
                        break;
                    case "100MeterHurdles33\"":
                    case "100MeterHurdles":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 13, null);
                        break;
                    case "300MeterHurdles30\"":
                    case "300MeterHurdles":
                    case "300MeterHurdlesTimedFinal":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 40, null);
                        break;
                    case "4x100MeterRelay":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 40, null);
                        break;
                    case "4x200MeterRelay":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 80, null);
                        break;
                    case "4x400MeterRelay":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 195, null);
                        break;
                    case "4x800MeterRelay":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 455, null);
                        break;
                    case "ShotPut":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 60, 840);
                        break;
                    case "DiscusThrow":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 60, 2400);
                        break;
                    case "HighJump":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 30, 90);
                        break;
                    case "LongJump":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 30, 300);
                        break;
                    case "PoleVault":
                        ThrowIfUnrealisticPerformance(data, eventName, eventGender, 30, 216);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ThrowIfUnrealisticPerformance(double data, string eventName, string eventGender, double? lowerLimit, double? upperLimit)
        {
            if (lowerLimit.HasValue && data < lowerLimit.Value)
            {
                throw new ArgumentOutOfRangeException(nameof(data), data, $"Unrealistic performance for {eventGender} {eventName}: {data}");
            }

            if (upperLimit.HasValue && data > upperLimit.Value)
            {
                throw new ArgumentOutOfRangeException(nameof(data), data, $"Unrealistic performance for {eventGender} {eventName}: {data}");

            }
        }
    }
}