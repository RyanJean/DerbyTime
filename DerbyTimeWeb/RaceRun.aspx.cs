using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DerbyTimeWeb
{
    public partial class RaceRun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadParameters();
        }

        void LoadParameters()
        {
            var schedule = MySession.Current.Schedule;
            var heats = MySession.Current.Heats;
            var complete = heats.Length >= schedule.Length;

            if (!complete)
            {
                leftZone.Controls.Clear();
                leftZone.Controls.Add(new LiteralControl("<h2>This Heat</h2>"));
                var v = Utilities.ThisHeat();
                var row = new TableRow();
                for (var i = 0; i < MySession.Current.num_Lanes; i++)
                {
                    var ddl = new DropDownList();
                    ddl.ID = "lane" + i;
                    ddl.Items.Add(new ListItem("----", ""));
                    ddl.Items.AddRange(Enumerable.Range(1, MySession.Current.num_Lanes).Select(q => new ListItem(q.ToString(), (MySession.Current.num_Lanes + 1 - q).ToString())).ToArray());
                    var cell = new TableCell();
                    cell.Controls.Add(ddl);
                    cell.Style.Add("text-align", "center");
                    row.Controls.Add(cell);
                }
                v.Controls.Add(row);
                {
                    row = new TableRow();
                    var spreadcell = new TableCell();
                    spreadcell.ColumnSpan = MySession.Current.num_Lanes;
                    spreadcell.Style.Add("text-align", "center");
                    var btn = new Button();
                    btn.Text = "Submit Heat Results";
                    btn.Click += heat_Results;
                    spreadcell.Controls.Add(btn);
                    row.Controls.Add(spreadcell);
                }
                v.Controls.Add(row);
                leftZone.Controls.Add(v);
                leftZone.Controls.Add(new LiteralControl("<br/><h2>Upcoming Heats</h2>"));
                leftZone.Controls.Add(Utilities.Next10Heats());

                rightZone.Controls.Clear();
                rightZone.Controls.Add(new LiteralControl("<a href='RaceStats.aspx' target='_blank'>Open Spectator Window</a><br />"));
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

        void heat_Results(object sender, EventArgs e)
        {
            var x = Enumerable.Range(0, MySession.Current.num_Lanes)
                .Select(q => ((DropDownList)leftZone.FindControl("lane" + q)).SelectedValue)
                .Where(q => !string.IsNullOrEmpty(q)).Distinct();
            if (x.Count() != MySession.Current.num_Lanes)
                errZone.Controls.Add(new LiteralControl("<span style=\"color:red;font-weight:bold;\">Error: Not all lanes have proper values!</span>"));
            else
            {
                MySession.Current.AddHeat(x.Select(q => int.Parse(q)).ToArray());
                LoadParameters();
            }
        }
    }
}