using System.Collections.Generic;
using System.Linq;

namespace DerbyRaceScheduler.Schedulers
{
    class BasicLaneRotation : IScheduler
    {
        SchedulerDetails IScheduler.Details { get { return new SchedulerDetails(
            this.GetType().Name,
            "Basic Lane Rotation",
            "This racing schedule supports all lane and car counts, and any number of rounds from 1-12 regardless of lane/car counts.\r\n\r\nThis is the most simplistic schedule, and guarantees only that each car will race once per lane, per round.\r\n\r\nRandomness is low, and cars will always be matched up against the same other cars."
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
            range = range.Concat(range);

            List<int[]> Heats = new List<int[]>();
            for (int i = 0; i < runs; i++)
            {
                List<int[]> Run = new List<int[]>();
                for (int j = 0; j < cars; j++)
                    Run.Add(range.Skip(j).Take(lanes).ToArray());
                if (shuffle) Run.Shuffle();
                Heats.AddRange(Run.ToArray());
            }
            return new RaceSchedule("Basic Lane Rotation", lanes, cars, runs, Heats.ToArray());
        }
    }
}
