using System;
using System.Collections.Generic;
using System.Linq;

namespace DerbyRaceScheduler.Schedulers
{
    class ChaoticLaneRotation : IScheduler
    {
        SchedulerDetails IScheduler.Details { get { return new SchedulerDetails(
            this.GetType().Name,
            "Chaotic Lane Rotation",
            "This racing schedule supports all lane and car counts, and any number of rounds from 1-12 regardless of lane/car counts.\r\n\r\nThis is the most random schedule, and guarantees that each car will race once per lane, per round, but randomizes the opponents otherwise."
        ); } }

        RunSetInformation[] IScheduler.getAvailableRuns(int lanes, int cars)
        {
            Utilities.ExceptionCheck(lanes, cars);
            var range = Enumerable.Range(1, 12);
            return range.Select(r => new RunSetInformation(r, null)).ToArray();
        }

        RaceSchedule IScheduler.getRaceSchedule(int lanes, int cars, int runs, bool shuffle)
        {
            Utilities.ExceptionCheck(lanes, cars, runs);
            var range = Enumerable.Range(1, cars);
            var rand = new Random();

            List<int[]> Heats = new List<int[]>();
            for (int i = 0; i < runs; i++)
            {
                var ranges = new List<List<int>>();
                foreach (int lane in Enumerable.Range(0, lanes - 1))
                    ranges.Add(range.ToList());
                List<int[]> Run = new List<int[]>();
                try
                {
                    for (int j = 0; j < cars; j++)
                    {
                        var thisHeat = new int[] { j + 1 };
                        foreach (var laneRange in ranges)
                        {
                            var r = laneRange.Except(thisHeat);
                            var q = r.Skip(rand.Next(r.Count())).First();
                            thisHeat = thisHeat.Concat(new int[] { q }).ToArray();
                            laneRange.Remove(q);
                        }
                        Run.Add(thisHeat);
                    }
                }
                catch
                {
                    // This prevents certain problems when chaotic selection happens to go out of order
                    // and it gets to the last heat of the run and has accidentally scheduled a car
                    // to run against itself. It seems to happen about 1/4 of the runs. If we find that
                    // problem, simply back up (iteration --) and re-do the entire run (for-continue).
                    i--;
                    continue;
                }
                if (shuffle) Run.Shuffle();
                Heats.AddRange(Run.ToArray());
            }
            return new RaceSchedule("Chaotic Lane Rotation", lanes, cars, runs, Heats.ToArray());
        }
    }
}
