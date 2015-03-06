using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DerbyTime.Controls
{
    public partial class DriverControl : UserControl
    {
        Racer r;

        public DriverControl(Racer r)
        {
            this.r = r;
            
            InitializeComponent();
            lbl_RaceNum.Text = r.raceNo.ToString();
            lbl_RaceNum.Image = ImageHandling.GetResizedImage(
                global::DerbyTime.Properties.Resources.Graphics_Oval, lbl_RaceNum.ClientRectangle);
            lbl_ChildName.Text = r.name.ToString();
            lbl_PackNo.Text += r.pack.ToString();
            lbl_Den.Text += " " + r.den.ToString();
            if (r.den != Den.None)
            {
                switch (r.den)
                {
                    case Den.Bobcat: img_Den.BackgroundImage = global::DerbyTime.Properties.Resources.Badge_Bobcat_1200; break;
                    case Den.Tiger: img_Den.BackgroundImage = global::DerbyTime.Properties.Resources.Badge_Tiger_1200; break;
                    case Den.Wolf: img_Den.BackgroundImage = global::DerbyTime.Properties.Resources.Badge_Wolf_1200; break;
                    case Den.Bear: img_Den.BackgroundImage = global::DerbyTime.Properties.Resources.Badge_Bear_1200; break;
                    case Den.Webelos: img_Den.BackgroundImage = global::DerbyTime.Properties.Resources.Badge_Webelos_1200; break;
                }
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            EditDriver edit = new EditDriver(r);
            edit.ShowDialog();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            MainScreen.scr_Drivers.RemoveDriver(this.r);
        }

    }
}
