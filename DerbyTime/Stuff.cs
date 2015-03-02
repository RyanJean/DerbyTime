using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DerbyTime
{
    public class ConfigDetails
    {
        public int PackNumber { get; private set; }
        public string PackLocation { get; private set; }
        public string ChosenScheduler { get; private set; }
        public int NumberOfLanes { get; private set; }
        public bool Shuffle { get; private set; }
        public ConfigDetails(int PackNumber, string PackLocation, string ChosenScheduler, int NumberOfLanes, bool Shuffle)
        {
            this.PackNumber = PackNumber;
            this.PackLocation = PackLocation;
            this.ChosenScheduler = ChosenScheduler;
            this.NumberOfLanes = NumberOfLanes;
            this.Shuffle = Shuffle;
        }
    }

    public class Racer
    {
        public Den den;
        public string name;

        public Racer(Den den, string name)
        {
            this.den = den;
            this.name = name;
        }
    }

    public enum Den { Webelos = 5, Bear = 4, Wolf = 3, Tiger = 2, Bobcat = 1, None = 0 }
}
