using DerbyRaceScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DerbyTime
{
    public partial class RaceLoadScreen : Form
    {
        public RaceLoadScreen()
        {
            InitializeComponent();
            var cfg = Program.Interface.getConfig();
            var scheduler = RaceScheduler.GetScheduler(RaceScheduler.GetAllSchedulers()
                .Where(q => q.SchedulerName == cfg.ChosenScheduler).First());
            var schedules = scheduler.getAvailableRuns(cfg.NumberOfLanes, Program.Interface.getDrivers().Count);
            comboBox1.Items.AddRange(schedules.Select(q => new Item(q.RunSetName, q.NumberOfRuns, Program.Interface.getDrivers().Count)).ToArray());
            comboBox1.SelectedValue = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainScreen.action_Race_Start((int)comboBox1.SelectedValue);
            Close();
        }
    }
}
