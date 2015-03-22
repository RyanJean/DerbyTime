using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DerbyTimeWeb
{
    public partial class RaceStats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MySession.Current.isUpdate = false;

            var schedule = MySession.Current.Schedule;
            var heats = MySession.Current.Heats;
            var complete = heats.Length >= schedule.Length;

            if (!complete)
            {
                leftZone.Controls.Clear();
                leftZone.Controls.Add(new LiteralControl("<h2>This Heat</h2>"));
                leftZone.Controls.Add(Utilities.ThisHeat());
                leftZone.Controls.Add(new LiteralControl("<h2>Upcoming Heats</h2>"));
                leftZone.Controls.Add(Utilities.Next10Heats());

                rightZone.Controls.Clear();
                rightZone.Controls.Add(new LiteralControl("<h2>Leaderboard</h2>"));
                rightZone.Controls.Add(Utilities.LeaderBoard());
            }
            else
            {
                finalScoreZone.Controls.Add(Utilities.LeaderBoard());
                completeZone.Visible = true;
                notCompleteZone.Visible = false;
            }
        }
    }
}