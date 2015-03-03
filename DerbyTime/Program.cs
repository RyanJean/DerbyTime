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
        public static ConfigDetails Config { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoadConfig();
            Application.Run(new SplashScreen());
            Application.Run(new MainScreen());
        }

        public static void LoadConfig(ConfigDetails CFG = null)
        {
            if (CFG != null)
            {
                Config = CFG;
                string cfg = string.Format(
                    string.Format(
                        "<root>{0}{1}{2}{3}{4}{5}\r\n</root>\r\n",
                        Enumerable.Range(0, 6).Select(q => "\r\n\t<{" + q + "}>{" + (q + 6) + "}</{" + q + "}>").ToArray()
                        ),
                    "packNumber", "packLocation", "chosenScheduler", "numberOfLanes", "shuffleHeats", "saveRace",
                    CFG.PackNumber, CFG.PackLocation, CFG.ChosenScheduler, CFG.NumberOfLanes, CFG.Shuffle, CFG.SaveRace);
                File.WriteAllText("Derby.config", cfg);
                return;
            }

            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load("Derby.config");
                var root = xDoc.DocumentElement;
                Config = new ConfigDetails(
                    int.Parse(root.GetElementsByTagName("packNumber")[0].InnerText),
                    root.GetElementsByTagName("packLocation")[0].InnerText,
                    root.GetElementsByTagName("chosenScheduler")[0].InnerText,
                    int.Parse(root.GetElementsByTagName("numberOfLanes")[0].InnerText),
                    bool.Parse(root.GetElementsByTagName("shuffleHeats")[0].InnerText),
                    bool.Parse(root.GetElementsByTagName("saveRace")[0].InnerText)
                );
            }
            catch
            {
                Config = null;
            }
        }
    }
}
