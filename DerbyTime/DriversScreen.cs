using DerbyTime.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DerbyTime
{
    public partial class DriversScreen : Form
    {
        public static List<Racer> Drivers = new List<Racer>();
        
        public DriversScreen()
        {
            InitializeComponent();
            ShowScrollBar(DriversPanel.Handle, 1 /* vert */, true);
            Drivers = Program.Interface.getDrivers();
            RefreshList();
        }

        public void RefreshList()
        {
            DriversPanel.Controls.Clear();
            foreach (Racer r in Drivers.OrderBy(q => q.raceNo))
                DriversPanel.Controls.Add(new DriverControl(r));
            btn_Load.Enabled = (Drivers.Count == 0);
            btn_Save.Enabled = (Drivers.Count >= Program.Interface.getConfig().NumberOfLanes);
        }

        public void RemoveDriver(Racer r)
        {
            Drivers.Remove(r);
        }

        // This is used to allow us to force the vertical scrollbar on the panel.
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            Program.Interface.setDrivers(Drivers);
            Close();
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Driver List (*.drvr)|*drvr|Race Capture (*.race)|*.race";
                ofd.Title = "Load a Driver Manifest File";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string s;
                    using (Stream st = ofd.OpenFile())
                    {
                        byte[] b = new byte[(int)st.Length];
                        st.Read(b, 0, (int)st.Length);
                        s = Encoding.ASCII.GetString(b);
                    }
                    s = Regex.Match(s, "## Drivers.*?(?=($|\r\n##))", RegexOptions.Singleline).Value;
                    s = Regex.Replace(s, "## Drivers\r\n", "");
                    s = Regex.Replace(s, "\r\n", "\n");
                    foreach (string ss in s.Split('\n').Take(200))
                    {
                        string[] sss = ss.Split('\t');
                        try {
                            var r = new Racer(int.Parse(sss[0]), int.Parse(sss[1]), (Den)Enum.Parse(typeof(Den), sss[2]), sss[3]);
                            Drivers.Add(r);
                            if (!EditDriver.packs.Contains(sss[1]))
                                EditDriver.packs.Add(sss[1]);
                        } catch { }
                    }
                }
            }
            RefreshList();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Driver List (*.drvr)|*.drvr";
                sfd.Title = "Save a Driver Manifest File";
                sfd.FileName = DateTime.Now.ToString("yyMMdd_HHmm") + ".drvr";
                sfd.OverwritePrompt = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string s = "## Drivers\r\n" + string.Join("\r\n", Drivers.OrderBy(q => q.raceNo).Select(q =>
                        string.Format("{0}\t{1}\t{2}\t{3}", q.raceNo, q.pack, q.den.ToString(), q.name)).ToArray());
                    using (Stream st = sfd.OpenFile())
                        st.Write(Encoding.ASCII.GetBytes(s), 0, Encoding.ASCII.GetByteCount(s));
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (Drivers.Count >= 200)
            {
                MessageBox.Show("You may not have over 200 cars!", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            EditDriver edit = new EditDriver();
            edit.ShowDialog();
            RefreshList();
        }

    }
}
