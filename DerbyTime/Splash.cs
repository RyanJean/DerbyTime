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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            Timer t = new Timer();
            t.Interval = 3500;
            t.Tick += t_Tick;
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
