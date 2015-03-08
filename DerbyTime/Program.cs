using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace DerbyTime
{
    static class Program
    {
        public static MasterInterface Interface = new MasterInterface();
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoadConfig();
            Application.Run(new SplashScreen());
            Application.Run(new MainScreen());
        }

        static void LoadConfig()
        {
            XmlDocument xDoc = new XmlDocument();
            try {
                xDoc.Load("Derby.config");
                var root = xDoc.DocumentElement;
                Interface.setConfig(new ConfigDetails(
                    int.Parse(root.GetElementsByTagName("packNumber")[0].InnerText),
                    root.GetElementsByTagName("packLocation")[0].InnerText,
                    root.GetElementsByTagName("chosenScheduler")[0].InnerText,
                    int.Parse(root.GetElementsByTagName("numberOfLanes")[0].InnerText),
                    bool.Parse(root.GetElementsByTagName("shuffleHeats")[0].InnerText),
                    bool.Parse(root.GetElementsByTagName("saveRace")[0].InnerText)
                ));
            } catch { }
        }
    }

    public class MasterInterface
    {
        private ConfigDetails Config = null;
        private List<Racer> Drivers = new List<Racer>();

        public DriversScreen scr_Drivers = null;
        public RaceScreen scr_Race = null;
        public AboutScreen scr_About = null;

        public ConfigDetails getConfig() { return Config; }
        public void setConfig(ConfigDetails cfg)
        {
            Config = cfg;
            string str_cfg = string.Format(
                string.Format(
                    "<root>{0}{1}{2}{3}{4}{5}\r\n</root>\r\n",
                    Enumerable.Range(0, 6).Select(q => "\r\n\t<{" + q + "}>{" + (q + 6) + "}</{" + q + "}>").ToArray()
                    ),
                "packNumber", "packLocation", "chosenScheduler", "numberOfLanes", "shuffleHeats", "saveRace",
                cfg.PackNumber, cfg.PackLocation, cfg.ChosenScheduler, cfg.NumberOfLanes, cfg.Shuffle, cfg.SaveRace);
            File.WriteAllText("Derby.config", str_cfg);
        }

        public List<Racer> getDrivers() { return Drivers.ToList(); }
        public void setDrivers(List<Racer> drv) { Drivers = drv.OrderBy(q => q.raceNo).ToList(); }
    }
}
