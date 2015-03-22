using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DerbyTimeWeb
{
    public class MySession
    {
        // private constructor
        private MySession()
        {
            isConfig = false;
            isDrivers = false;
            isSchedule = false;
            isUpdate = false;
#if DEBUG
            isConfig = true;
            _packNum = 1559;
            _packLoc = "Bowie, MD";
            _numLanes = 3;
            isDrivers = true;
            _Drivers.Add(new string[] { "1", "2", "Jean", "Ryan", "Webelos" });
            _Drivers.Add(new string[] { "2", "3", "Jean", "Christine", "Bear" });
            _Drivers.Add(new string[] { "3", "5", "Jean", "Lucas", "Wolf" });
            _Drivers.Add(new string[] { "4", "7", "Jean", "Logan", "Tiger" });
            //AddHeat(new int[] { 1, 2, 3 });
            //AddHeat(new int[] { 1, 3, 2 });
            //AddHeat(new int[] { 2, 1, 3 });
            //AddHeat(new int[] { 2, 3, 1 });
#endif
        }

        // Gets the current session.
        public static MySession Current
        {
            get
            {
                MySession session =
                  (MySession)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }

        // **** add your session properties here, e.g like this:

        public bool isConfig { get; private set; }
        public bool isDrivers { get; private set; }
        public bool isSchedule { get; private set; }
        public bool isUpdate { get; set; }

        // Configuration Variables
        public int pack_Num { get { return _packNum; } }
        private int _packNum = 0;
        public string pack_Loc { get { return _packLoc; } }
        private string _packLoc = "";
        public int num_Lanes { get { return _numLanes; } }
        private int _numLanes = 0;

        public void Config(int packNum, string packLoc, int numLanes) { _packNum = packNum; _packLoc = packLoc; _numLanes = numLanes; isConfig = true; }

        // Driver Variables
        public string[][] Drivers { get { return _Drivers.ToArray(); } }
        private List<string[]> _Drivers = new List<string[]>();
        public void SaveDrivers(List<string[]> driverList) { int ctr = 0; _Drivers = driverList.Select(q => new string[] { (++ctr).ToString() }.Concat(q).ToArray()).ToList(); isDrivers = (_Drivers.Count >= num_Lanes); }

        // Schedule Variables
        public int[][] Schedule { get { return _Schedule.ToArray(); } }
        private List<int[]> _Schedule = new List<int[]>();
        public void SaveSchedule(List<int[]> scheduleList) { _Schedule = scheduleList.ToList(); isSchedule = (_Schedule.Count > 0 && _Drivers.Count > 0) ? (_Schedule.Count % _Drivers.Count == 0) : false; }

        // Heat Variables
        public int[][] Heats { get { return _Heats.ToArray(); } }
        private List<int[]> _Heats = new List<int[]>();
        public void AddHeat(int[] heat) { _Heats.Add(heat); isUpdate = true; }
    }
}