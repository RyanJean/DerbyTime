using DerbyRaceScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DerbyTime
{
    public partial class ConfigurationSettings : Form
    {
        private ConfigDetails Config;
        private SchedulerDetails[] Details;
        public ConfigurationSettings(ConfigDetails cfg)
        {
            Config = cfg;
            Details = RaceScheduler.GetAllSchedulers();
            InitializeComponent();

            this.fld_PackNumber.MaxLength = 6;
            this.fld_PackNumber.TextChanged += fld_PackNumber_TextChanged;
            this.fld_PackLocation.MaxLength = 50;
            this.fld_LaneCount.Items.AddRange(Enumerable.Range(2, 5).Select(q => q.ToString()).ToArray());
            this.fld_LaneCount.SelectedIndex = 0;
            this.fld_LaneCount.DropDownStyle = ComboBoxStyle.DropDownList;
            this.fld_Algorithm.Items.AddRange(Details.Select(q => q.SchedulerName).ToArray());
            this.fld_Algorithm.SelectedIndex = 0;
            this.fld_Algorithm.DropDownStyle = ComboBoxStyle.DropDownList;
            this.fld_Algorithm.SelectedIndexChanged += fld_Algorithm_SelectedIndexChanged;
            this.AlgorithmInfo.Text = Details.Where(q => q.SchedulerName == fld_Algorithm.SelectedItem).First().Description;
            this.AlgorithmInfo.ReadOnly = true;
            this.AlgorithmInfo.ScrollBars = ScrollBars.Vertical;
            if (Config != null)
            {
                fld_PackNumber.Text = Config.PackNumber.ToString();
                fld_PackLocation.Text = Config.PackLocation;
                fld_LaneCount.SelectedItem = Config.NumberOfLanes.ToString();
                fld_Algorithm.SelectedItem = Config.ChosenScheduler;
                fld_Shuffle.Checked = Config.Shuffle;
                fld_SaveRace.Checked = Config.SaveRace;
            }
            else
            {
                btn_Cancel.Enabled = false;
            }
            btn_Save.Click += btn_Save_Click;
            btn_Cancel.Click += btn_Cancel_Click;
        }

        void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btn_Save_Click(object sender, EventArgs e)
        {
            var PackNumber = 0;
            if (!string.IsNullOrEmpty(fld_PackNumber.Text))
                PackNumber = int.Parse(fld_PackNumber.Text);
            var PackLocation = fld_PackLocation.Text;
            var LaneCount = int.Parse(fld_LaneCount.SelectedItem.ToString());
            var Algorithm = fld_Algorithm.SelectedItem.ToString();
            var Shuffle = fld_Shuffle.Checked;
            var SaveRace = fld_SaveRace.Checked;

            Config = new ConfigDetails(PackNumber, PackLocation, Algorithm, LaneCount, Shuffle, SaveRace);
            Program.LoadConfig(Config);
            this.Close();
        }

        void fld_Algorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            AlgorithmInfo.Text = Details.Where(q => q.SchedulerName == fld_Algorithm.SelectedItem).First().Description;
        }

        void fld_PackNumber_TextChanged(object sender, System.EventArgs e)
        {
            fld_PackNumber.Text = Regex.Replace(fld_PackNumber.Text, "[^\\d]", "");
        }

    }
}
