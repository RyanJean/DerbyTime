using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DerbyTimeWeb
{
    public class Utilities
    {
        public static Table LeaderBoard()
        {
            var sched = MySession.Current.Schedule;
            var heats = MySession.Current.Heats;
            var iscomplete = (sched.Length == heats.Length);
            var drivermap = MySession.Current.Drivers.Select(q => new int[] { int.Parse(q[0]), 0, 0 }).ToArray();
            for (int i = 0; i < heats.Length; i++)
            {
                var thisSched = sched[i];
                var thisScore = heats[i];
                for (int j = 0; j < thisSched.Length; j++)
                {
                    var thisDriver = drivermap.Where(q => q[0] == thisSched[j]).First();
                    thisDriver[1] += thisScore[j];
                    thisDriver[2]++;
                }
            }
            var driverscore = drivermap.Where(q => q[2] > 0).Select(q => new object[] { q[0], (double)q[1] / q[2] });
            var driverboard = driverscore.Select(q => new LeaderBoardEntry()
                { car = MySession.Current.Drivers.Where(r => int.Parse(r[0]) == (int)q[0])
                    .Select(s => string.Format("{0} - {1}, {2}", s[1], s[2], s[3])).First(),
                  score = (double)q[1]}).OrderByDescending(t => t.score).ThenBy(t => t.car);

            var tbl = new Table();
            tbl.CssClass = (iscomplete) ? "leaderboard" : "winnerboard";
            tbl.CellSpacing = 0;
            var hrow = new TableHeaderRow();
            var hcell = new TableHeaderCell() { Text = "Place" };
            hrow.Controls.Add(hcell);
            hcell = new TableHeaderCell() { Text = "Car" };
            hrow.Controls.Add(hcell);
            hcell = new TableHeaderCell() { Text = "Score" };
            hrow.Controls.Add(hcell);
            // For spacing out an extra column when there's a winner
            if (iscomplete) hrow.Controls.Add(new TableHeaderCell());
            tbl.Controls.Add(hrow);

            int ctr = 0;
            foreach (var v in driverboard)
            {
                var row = new TableRow();
                row.Controls.Add(new TableCell() { Text = (++ctr).ToString() });
                row.Controls.Add(new TableCell() { Text = v.car });
                row.Controls.Add(new TableCell() { Text = v.printScore });
                if (iscomplete)
                {
                    var cell = new TableCell();
                    switch (ctr)
                    {
                        case 1:
                            cell.Controls.Add(new Image() { Width = 30, ImageUrl = "~/Images/Awards/Ribbon1.png" });
                            break;
                        case 2:
                            cell.Controls.Add(new Image() { Width = 30, ImageUrl = "~/Images/Awards/Ribbon2.png" });
                            break;
                        case 3:
                            cell.Controls.Add(new Image() { Width = 30, ImageUrl = "~/Images/Awards/Ribbon3.png" });
                            break;
                        default:
                            break;
                    }
                    row.Controls.Add(cell);
                }
                tbl.Controls.Add(row);
            }
            return tbl;
        }

        public static Table Next10Heats()
        {
            var sched = MySession.Current.Schedule;
            var heats = MySession.Current.Heats;
            var drivers = MySession.Current.Drivers;
            var lanes = MySession.Current.num_Lanes;

            var next10 = sched.Skip(heats.Length + 1).Take(10).Select(q => q.Select(r => drivers.Where(s => int.Parse(s[0]) == r).Select(t => string.Format("{0} - {1}, {2}", t[1], t[2], t[3])).First()).ToArray());
            
            var tbl = new Table();
            tbl.CssClass = "heats";
            tbl.CellSpacing = 0;
            var hrow = new TableHeaderRow();
            for (int i = 1; i <= MySession.Current.num_Lanes; i++)
                hrow.Controls.Add(new TableHeaderCell() { Text = "Lane " + i });
            tbl.Controls.Add(hrow);
            foreach (var v in next10)
            {
                var row = new TableRow();
                foreach (var w in v)
                    row.Controls.Add(new TableCell() { Text = (w + "               ").Substring(0, 15).Trim() });
                tbl.Controls.Add(row);
            }
            return tbl;
        }

        public static Table ThisHeat()
        {
            var sched = MySession.Current.Schedule;
            var heats = MySession.Current.Heats;
            var drivers = MySession.Current.Drivers;
            var lanes = MySession.Current.num_Lanes;

            var next1 = sched.Skip(heats.Length).Take(1).Select(q => q.Select(r => drivers.Where(s => int.Parse(s[0]) == r).Select(t => string.Format("{0} - {1}, {2}", t[1], t[2], t[3])).First()).ToArray());

            var tbl = new Table();
            tbl.CssClass = "heats";
            tbl.CellSpacing = 0;
            var hrow = new TableHeaderRow();
            for (int i = 1; i <= MySession.Current.num_Lanes; i++)
                hrow.Controls.Add(new TableHeaderCell() { Text = "Lane " + i });
            tbl.Controls.Add(hrow);
            foreach (var v in next1)
            {
                var row = new TableRow();
                foreach (var w in v)
                    row.Controls.Add(new TableCell() { Text = (w + "               ").Substring(0, 15).Trim() });
                tbl.Controls.Add(row);
            }
            return tbl;
        }
    }

    public struct LeaderBoardEntry
    {
        public string car { get { return _car.Substring(0, 15).Trim(); } set { _car = value + "               "; } }
        private string _car;
        public double score;
        public string printScore { get { return (score.ToString() + "    ").Substring(0, 4).Trim(); } }
    }
}