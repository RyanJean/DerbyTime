using DerbyRaceScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DerbyTimeWeb
{
    public partial class RaceSetup : System.Web.UI.Page
    {
        SchedulerDetails[] s = RaceScheduler.GetAllSchedulers();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                runs.Enabled = false;
                confirm.Enabled = false;

                sched.Items.Add(new ListItem("-- SELECT --", ""));
                sched.Items.AddRange(s.Select(q => new ListItem(q.SchedulerName, q.ClassName)).ToArray());
            }
        }

        protected void sched_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sched.SelectedIndex != 0)
            {
                runs.Enabled = true;
                runs.Items.Clear();
                runs.Items.Add(new ListItem("-- SELECT --", ""));
                var v = s.Where(q => q.ClassName.Equals(sched.SelectedValue)).First();
                var l = MySession.Current.num_Lanes;
                var c = MySession.Current.Drivers.Length;
                var r = RaceScheduler.GetScheduler(v).getAvailableRuns(l, c).Select(q => new object[] { q.NumberOfRuns, q.RunSetName });
                var r2 = r.Select(q => new string[] { string.Format("{0} Runs ({1} Heats) {2}", q[0], (int)q[0] * c, q[1]), q[0].ToString() });
                runs.Items.AddRange(r2.Select(q => new ListItem(q[0], q[1])).ToArray());
            }
            else
            {
                runs.Enabled = false;
                runs.Items.Clear();
                confirm.Enabled = false;
            }
        }

        protected void runs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (runs.SelectedIndex != 0)
                confirm.Enabled = true;
            else
                confirm.Enabled = false;
        }

        protected void confirm_Click(object sender, EventArgs e)
        {
            var x = RaceScheduler.GetScheduler(s.Where(q => q.ClassName.Equals(sched.SelectedValue)).First());
            var l = MySession.Current.num_Lanes;
            var c = MySession.Current.Drivers.Length;
            var r = int.Parse(runs.SelectedValue);

            var y = x.getRaceSchedule(l, c, r, true);
            MySession.Current.SaveSchedule(y.Heats.ToList());
            Response.Redirect("RaceRun.aspx");
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}