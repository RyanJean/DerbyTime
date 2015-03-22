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
    public partial class EditDriver : Form
    {
        Racer r = null;
        public static List<string> packs = new List<string>();
        IEnumerable<int> range = Enumerable.Range(1, 200);

        public EditDriver()
        {
            if (!packs.Contains(Program.Interface.getConfig().PackNumber.ToString()))
                packs.Add(Program.Interface.getConfig().PackNumber.ToString());
            InitializeComponent();
            range = range.Except(DriversScreen.Drivers.Select(q => q.raceNo)).OrderBy(q => q);
            ddl_DriverNo.Items.AddRange(range.Select(q => q.ToString()).ToArray());
            ddl_DriverNo.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl_DriverNo.SelectedItem = range.First().ToString();
            ddl_Pack.Items.AddRange(packs.ToArray());
            ddl_Pack.SelectedItem = Program.Interface.getConfig().PackNumber.ToString();
            ddl_Den.Items.AddRange(Enum.GetNames(typeof(Den)));
            ddl_Den.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl_Den.SelectedItem = "None";
        }

        public EditDriver(Racer r)
        {
            this.r = r;
            if (!packs.Contains(Program.Interface.getConfig().PackNumber.ToString()))
                packs.Add(Program.Interface.getConfig().PackNumber.ToString());
            InitializeComponent();
            range = range.Except(DriversScreen.Drivers.Select(q => q.raceNo)).Concat(new int[] { r.raceNo }).OrderBy(q => q);
            ddl_DriverNo.Items.AddRange(range.Select(q => q.ToString()).ToArray());
            ddl_DriverNo.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl_DriverNo.SelectedItem = r.raceNo.ToString();
            ddl_Pack.Items.AddRange(packs.ToArray());
            ddl_Pack.SelectedItem = r.pack.ToString();
            ddl_Den.Items.AddRange(Enum.GetNames(typeof(Den)));
            ddl_Den.DropDownStyle = ComboBoxStyle.DropDownList;
            ddl_Den.SelectedItem = r.den.ToString();
            txt_Name.Text = r.name;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            // Pack # errors
            if (string.IsNullOrEmpty(ddl_Pack.Text))
                lbl_Err.Text = "Error: Must have a pack #";
            else if (Regex.IsMatch(ddl_Pack.Text, "[^\\d]"))
                lbl_Err.Text = "Error: Pack # must be a number";
            // Name errors
            else if (txt_Name.Text.Length < 3)
                lbl_Err.Text = "Error: Name too short";
            else
            {
                if (!packs.Contains(ddl_Pack.Text))
                    packs.Add(ddl_Pack.Text);
                Racer rx = new Racer(
                    int.Parse(ddl_DriverNo.Text),
                    int.Parse(ddl_Pack.Text),
                    (Den)Enum.Parse(typeof(Den), ddl_Den.Text),
                    txt_Name.Text);

                if (r == null)
                    DriversScreen.Drivers.Add(rx);
                else
                {
                    DriversScreen.Drivers.Remove(r);
                    DriversScreen.Drivers.Add(rx);
                }
                Close();
            }
        }
    }
}
