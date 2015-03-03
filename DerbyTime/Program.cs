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
                    "<root>\r\n\t<{0}>{5}</{0}>\r\n\t<{1}>{6}</{1}>\r\n\t<{2}>{7}</{2}>\r\n\t<{3}>{8}</{3}>\r\n\t<{4}>{9}</{4}>\r\n</root>\r\n",
                    "packNumber", "packLocation", "chosenScheduler", "numberOfLanes", "shuffleHeats",
                    CFG.PackNumber, CFG.PackLocation, CFG.ChosenScheduler, CFG.NumberOfLanes, CFG.Shuffle);
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
                    bool.Parse(root.GetElementsByTagName("shuffleHeats")[0].InnerText)
                );
            }
            catch
            {
                Config = null;
            }
        }
    }
}
