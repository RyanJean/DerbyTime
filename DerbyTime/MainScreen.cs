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
        ConfigurationSettings cfg = null;
        //Drivers
        //Race
        About about = null;

        List<Racer> Racers = new List<Racer>(); 

        public MainScreen()
        {
            InitializeComponent();
            btn_Race.Enabled = false;
        }

        private void btn_Config_Click(object sender, EventArgs e)
        {
            if (cfg == null)
                cfg = new ConfigurationSettings();
            cfg.ShowDialog();
        }

        private void btn_Drivers_Click(object sender, EventArgs e)
        {
            if (Racers.Count > 0)
                btn_Race.Enabled = true;
        }

        private void btn_Race_Click(object sender, EventArgs e)
        {

        }

        private void btn_About_Click(object sender, EventArgs e)
        {
            if (about == null)
                about = new About();
            about.ShowDialog();
        }
    }
}
