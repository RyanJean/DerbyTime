using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace DerbyRaceScheduler
{
    public static class RaceScheduler
    {
        public static SchedulerDetails[] GetAllSchedulers()
        {
            var schedulers = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.Namespace == "DerbyRaceScheduler.Schedulers");
            schedulers = schedulers.Where(t => !Regex.IsMatch(t.Name, "[<>+_]")).OrderBy(t => t.Name);
            var details = schedulers.Select(a => (IScheduler)Activator.CreateInstance(a)).Select(d => d.Details);
            return details.ToArray();
        }

        public static IScheduler GetScheduler(SchedulerDetails details)
        {
            var scheduler = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.Namespace == "DerbyRaceScheduler.Schedulers" && t.Name == details.ClassName).FirstOrDefault();
            return (IScheduler)Activator.CreateInstance(scheduler);
        }
    }
}
