namespace DerbyRaceScheduler
{
    public class RaceSchedule
    {
        public string Name { get; private set; }
        public int Lanes { get; private set; }
        public int Cars { get; private set; }
        public int Runs { get; private set; }
        public int[][] Heats { get; private set; }

        public RaceSchedule(string Name, int Lanes, int Cars, int Runs, int[][] Heats)
        {
            this.Name = Name;
            this.Lanes = Lanes;
            this.Cars = Cars;
            this.Runs = Runs;
            this.Heats = Heats;
        }
    }

    public class RunSetInformation
    {
        public int NumberOfRuns { get; private set; }
        public string RunSetName { get; private set; }

        public RunSetInformation(int NumberOfRuns, string RunSetName)
        {
            this.NumberOfRuns = NumberOfRuns;
            this.RunSetName = RunSetName;
        }
    }

    public class SchedulerDetails
    {
        public string ClassName { get; private set; }
        public string SchedulerName { get; private set; }
        public string Description { get; private set; }

        public SchedulerDetails(string ClassName, string SchedulerName, string Description)
        {
            this.ClassName = ClassName;
            this.SchedulerName = SchedulerName;
            this.Description = Description;
        }
    }
}
