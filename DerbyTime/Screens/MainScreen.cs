using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DerbyTime
{
    public partial class MainScreen : Form
    {
        static ConfigurationSettings cfg = null;
        static Timer t = new Timer();
        static int runsChosen = 0;

        public MainScreen()
        {
            InitializeComponent();
            // Set the Race button to disabled, as you can't Race without Drivers
            btn_Race.Enabled = false;
            // Start the timer to display the config screen (if needed)
            t.Interval = 500;
            t.Tick += t_Tick;
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            // Stop the timer so it doesn't fire again.
            // I would have called/used "public async void Execute(int timeout) { await Task.Delay(timeout); /* Other Commands */ }
            //   instead of a timer except that's .net 4.5 and I'm trying to keep this at 4.0 for older-system compatibility.
            t.Stop();
            t.Tick -= t_Tick;
            // If there's no loaded config, take us straight to the config screen.
            if (Program.Interface.getConfig() == null)
            {
                if (cfg == null) cfg = new ConfigurationSettings(Program.Interface.getConfig());
                cfg.ShowDialog();
            }
            // If there's *still* no config, exit the program.
            if (Program.Interface.getConfig() == null) Close();
        }

        private void btn_Config_Click(object sender, EventArgs e)
        {
            cfg = new ConfigurationSettings(Program.Interface.getConfig());
            cfg.ShowDialog();
            btn_Race.Enabled = Program.Interface.getDrivers().Count >= Program.Interface.getConfig().NumberOfLanes;
        }

        private void btn_Drivers_Click(object sender, EventArgs e)
        {
            Program.Interface.scr_Drivers = new DriversScreen();
            Program.Interface.scr_Drivers.ShowDialog();
            Program.Interface.scr_Drivers = null;
            btn_Race.Enabled = Program.Interface.getDrivers().Count >= Program.Interface.getConfig().NumberOfLanes;
        }

        private void btn_Race_Click(object sender, EventArgs e)
        {
            if (Program.Interface.scr_Race != null)
                Program.Interface.scr_Race.ShowDialog();
            else
            {
                Program.Interface.scr_RaceLoad = new RaceLoadScreen();
                Program.Interface.scr_RaceLoad.ShowDialog();
            }
        }

        private void btn_About_Click(object sender, EventArgs e)
        {
            if (Program.Interface.scr_About == null)
                Program.Interface.scr_About = new AboutScreen();
            Program.Interface.scr_About.ShowDialog();
        }

        static public void action_Race_Start(int runs)
        {
            if (runs > 0 && runs <= 12)
            {
                runsChosen = runs;
                t.Tick += action_Race_Start;
                t.Start();
            }
        }

        static void action_Race_Start(object sender, EventArgs e)
        {
            t.Stop();
            t.Tick -= action_Race_Start;
            if (Program.Interface.scr_Race == null)
                Program.Interface.scr_Race = new RaceScreen();
            Program.Interface.scr_Race.ShowDialog();
        }
    }
}
