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
    public partial class SplashScreen : Form
    {
        Timer t = new Timer();

        public SplashScreen()
        {
            InitializeComponent();
#if DEBUG
            t.Interval = 100;
#else
            t.Interval = 2500;
#endif
            t.Tick += t_Tick;
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            t.Stop();
            this.Close();
        }
    }
}
