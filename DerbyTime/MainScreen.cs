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
        ConfigurationSettings cfg = new ConfigurationSettings();
        DriversScreen scr_Drivers = new DriversScreen();
        RaceScreen scr_Race = new RaceScreen();
        AboutScreen scr_About = new AboutScreen();
        Timer t = new Timer();

        public MainScreen()
        {
            InitializeComponent();
            // Set the Race button to disabled, as you can't scr_Race without scr_Drivers
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
            // If there's no loaded config, take us straight to the config screen.
            if (Program.Config == null) cfg.ShowDialog();
            // If there's *still* no config, exit the program.
            if (Program.Config == null) Close();
        }

        private void btn_Config_Click(object sender, EventArgs e)
        {
            cfg.ShowDialog();
        }

        private void btn_Drivers_Click(object sender, EventArgs e)
        {
            scr_Drivers.ShowDialog();
            btn_Race.Enabled = scr_Drivers.Drivers.Count >= Program.Config.NumberOfLanes;
        }

        private void btn_Race_Click(object sender, EventArgs e)
        {
            scr_Race.ShowDialog();
        }

        private void btn_About_Click(object sender, EventArgs e)
        {
            scr_About.ShowDialog();
        }
    }
}
