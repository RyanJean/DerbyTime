using System;
using System.Collections.Generic;

namespace DerbyRaceScheduler
{
    public interface IScheduler
    {
        SchedulerDetails Details { get; }
        RunSetInformation[] getAvailableRuns(int lanes, int cars);
        RaceSchedule getRaceSchedule(int lanes, int cars, int runs, bool shuffle = false);

        /*
        // Default format for scheduler details section
        SchedulerDetails IScheduler.Details { get { return new SchedulerDetails(
            this.GetType().Name,
            "SCHEDULER'S COMMON NAME",
            "SCHEDULER'S DESCRIPTION"
        ); } }
        */

        /*
        // First line of both methods
        Utilities.ExceptionCheck(lanes, cars);
        */
    }

    internal static class Utilities
    {
        public static void ExceptionCheck(int lanes, int cars, int? runs = null)
        {
            if (lanes < 2)    throw new Exception("Error: You must have at least 2 lanes!");
            if (lanes > 6)    throw new Exception("Error: You may have at most 6 lanes!");
            if (cars < 2)     throw new Exception("Error: You must have at least 2 cars!");
            if (cars > 200)   throw new Exception("Error: You may have at most 200 cars!");
            if (cars < lanes) throw new Exception("Error: You must have at least as many cars as lanes!");
            if (runs != null)
            {
                if (runs < 1)  throw new Exception("Error: You must have at least 1 run!");
                if (runs > 12) throw new Exception("Error: You may have at most 12 runs!");
            }
        }
    }

    internal static class ExtensionMethods
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rnd = new Random();
            int n = list.Count;
            while (n > 1)
            {
                int k = rnd.Next(n--);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
