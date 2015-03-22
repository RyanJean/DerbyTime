using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DerbyTimeWeb
{
    public partial class Drivers : System.Web.UI.Page
    {
        List<string[]> driverList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                driverList = new List<string[]>();
                driverList.AddRange(MySession.Current.Drivers.Select(q => q.Skip(1).ToArray()).ToArray());
                Session["DriverList"] = driverList;
            }
            else
                driverList = (List<string[]>)Session["DriverList"];

            ErrZone.Controls.Clear();
            BuildControls();

            btn_submit.ServerClick += btn_submit_ServerClick;
        }

        void btn_submit_ServerClick(object sender, EventArgs e)
        {
            MySession.Current.SaveDrivers(driverList);
            Response.Redirect("Default.aspx");
        }

        private void BuildControls()
        {
            tZone.Controls.Clear();
            var tbl = new Table() { HorizontalAlign = HorizontalAlign.Center, CellSpacing = 0 };
            #region Header Row
            {
                var row = new TableHeaderRow();
                var cell = new TableHeaderCell() { Text = "Race #" };
                row.Controls.Add(cell);
                cell = new TableHeaderCell() { Text = "Driver's Name" };
                row.Controls.Add(cell);
                cell = new TableHeaderCell() { Text = "Den" };
                row.Controls.Add(cell);
                cell = new TableHeaderCell() { Text = "Options" };
                row.Controls.Add(cell);
                tbl.Controls.Add(row);
            }
            #endregion
            #region Existing Drivers
            {
                int ctr = 0;
                foreach (var v in driverList)
                {
                    var rowa = new TableRow();
                    var rowb = new TableRow();
                    rowa.ID = "rowa" + ctr;
                    rowb.ID = "rowb" + ctr;
                    rowa.ClientIDMode = ClientIDMode.Static;
                    rowb.ClientIDMode = ClientIDMode.Static;
                    rowb.Style.Add("display", "none");
                    // Column 1
                    var cell1 = new TableCell() { Text = "<span style=\"font-size: 1.2em; font-weight: bold;\">" + v[0] + "</span>" };
                    var cell2 = new TableCell();
                    var ddl = new DropDownList();
                    ddl.ID = "A" + ctr;
                    ddl.ClientIDMode = ClientIDMode.Static;
                    ddl.Items.AddRange(
                        Enumerable.Range(1, (driverList.Count * 3)%200 + 1)
                        .Except(driverList.Select(q => int.Parse(q[0]))
                            .Except(new[] { int.Parse(v[0]) }))
                        .Select(q => new ListItem(q.ToString(), q.ToString()))
                        .ToArray());
                    ddl.SelectedValue = v[0];
                    cell2.Controls.Add(ddl);
                    rowa.Controls.Add(cell1);
                    rowb.Controls.Add(cell2);
                    // Column 2
                    cell1 = new TableCell() { Text = v[1] + ",<br />" + v[2] };
                    cell2 = new TableCell();
                    var txt = new TextBox();
                    txt.ID = "B" + ctr;
                    txt.ClientIDMode = ClientIDMode.Static;
                    txt.Text = v[1];
                    cell2.Controls.Add(txt);
                    cell2.Controls.Add(new LiteralControl("<br />"));
                    txt = new TextBox();
                    txt.ID = "C" + ctr;
                    txt.ClientIDMode = ClientIDMode.Static;
                    txt.Text = v[2];
                    cell2.Controls.Add(txt);
                    rowa.Controls.Add(cell1);
                    rowb.Controls.Add(cell2);
                    // Column 3
                    cell1 = new TableCell();
                    cell2 = new TableCell();
                    var img = new Image();
                    img.Height = 50;
                    img.ImageUrl = BadgeUrl(v[3]);
                    cell1.Controls.Add(img);
                    ddl = new DropDownList();
                    ddl.ID = "D" + ctr;
                    ddl.ClientIDMode = ClientIDMode.Static;
                    ddl.Items.AddRange(Badges().Select(q => new ListItem(q, q)).ToArray());
                    ddl.SelectedValue = v[3];
                    cell2.Controls.Add(ddl);
                    rowa.Controls.Add(cell1);
                    rowb.Controls.Add(cell2);
                    // Column 4
                    cell1 = new TableCell();
                    cell2 = new TableCell();
                    var btn = new ImageButton();
                    btn.ID = "E" + ctr;
                    btn.ImageUrl = "~/Images/Menu/Menu_Edit.png";
                    btn.Height = 50;
                    btn.ClientIDMode = ClientIDMode.Static;
                    btn.OnClientClick = "javascript:return toggle('" + ctr + "', true);";
                    cell1.Controls.Add(btn);
                    btn = new ImageButton();
                    btn.ID = "F" + ctr;
                    btn.ImageUrl = "~/Images/Menu/Menu_Delete.png";
                    btn.Height = 50;
                    btn.ClientIDMode = ClientIDMode.Static;
                    btn.Click += delete_Driver;
                    cell1.Controls.Add(btn);
                    btn = new ImageButton();
                    btn.ID = "G" + ctr;
                    btn.ImageUrl = "~/Images/Menu/Menu_Edit.png";
                    btn.Height = 50;
                    btn.ClientIDMode = ClientIDMode.Static;
                    btn.OnClientClick = "javascript:return toggle('" + ctr + "', false);";
                    cell2.Controls.Add(btn);
                    btn = new ImageButton();
                    btn.ID = "H" + ctr;
                    btn.ImageUrl = "~/Images/Menu/Menu_Save.png";
                    btn.Height = 50;
                    btn.ClientIDMode = ClientIDMode.Static;
                    btn.Click += save_Driver;
                    cell2.Controls.Add(btn);
                    rowa.Controls.Add(cell1);
                    rowb.Controls.Add(cell2);
                    // Add Rows
                    tbl.Controls.Add(rowa);
                    tbl.Controls.Add(rowb);
                    ctr++;
                }
            }
            #endregion
            #region Add Driver
            {
                if (driverList.Count >= 200)
                {
                    tZone.Controls.Add(tbl);
                    return;
                }
                var row = new TableRow();
                row.ID = "rowAdd";
                row.ClientIDMode = ClientIDMode.Static;
                // Column 1
                var cell = new TableCell();
                var ddl = new DropDownList();
                ddl.ID = "A";
                ddl.ClientIDMode = ClientIDMode.Static;
                ddl.Items.AddRange(
                    Enumerable.Range(1, (driverList.Count * 3) % 200 + 1)
                    .Except(driverList.Select(q => int.Parse(q[0])))
                    .Select(q => new ListItem(q.ToString(), q.ToString()))
                    .ToArray());
                cell.Controls.Add(ddl);
                row.Controls.Add(cell);
                // Column 2
                cell = new TableCell();
                var txt = new TextBox();
                txt.ID = "B";
                txt.ClientIDMode = ClientIDMode.Static;
                txt.Text = "Last Name";
                cell.Controls.Add(txt);
                cell.Controls.Add(new LiteralControl("<br />"));
                txt = new TextBox();
                txt.ID = "C";
                txt.ClientIDMode = ClientIDMode.Static;
                txt.Text = "First Name";
                cell.Controls.Add(txt);
                row.Controls.Add(cell);
                // Column 3
                cell = new TableCell();
                ddl = new DropDownList();
                ddl.ID = "D";
                ddl.ClientIDMode = ClientIDMode.Static;
                ddl.Items.AddRange(Badges().Select(q => new ListItem(q, q)).ToArray());
                cell.Controls.Add(ddl);
                row.Controls.Add(cell);
                // Column 4
                cell = new TableCell();
                var btn = new ImageButton();
                btn.ImageUrl = "~/Images/Menu/Menu_Add.png";
                btn.Height = 50;
                btn.Click += add_Driver;
                cell.Controls.Add(btn);
                row.Controls.Add(cell);
                // Add Row
                tbl.Controls.Add(row);
            }
            #endregion
            tZone.Controls.Add(tbl);
        }

        void save_Driver(object sender, ImageClickEventArgs e)
        {
            var id = int.Parse(Regex.Match(((ImageButton)sender).ID, "\\d+").Value);
            bool err = false;
            var tb1 = ((TextBox)tZone.FindControl("B" + id)).Text.Trim();
            if (string.IsNullOrEmpty(tb1) || tb1.Equals("Last Name"))
                err = Err("Error: You must have a Last Name.");
            var tb2 = ((TextBox)tZone.FindControl("C" + id)).Text.Trim();
            if (string.IsNullOrEmpty(tb2) || tb2.Equals("First Name"))
                err = Err("Error: You must have a First Name.");
            if (!err)
            {
                driverList.RemoveAt(id);
                driverList.Add(new string[] { ((DropDownList)tZone.FindControl("A" + id)).SelectedValue, tb1, tb2, ((DropDownList)tZone.FindControl("D" + id)).SelectedValue });
                driverList = driverList.OrderBy(q => int.Parse(q[0])).ToList();
                Session["DriverList"] = driverList;
                BuildControls();
            }
        }

        void delete_Driver(object sender, ImageClickEventArgs e)
        {
            var id = int.Parse(Regex.Match(((ImageButton)sender).ID, "\\d+").Value);
            driverList.RemoveAt(id);
            driverList = driverList.OrderBy(q => int.Parse(q[0])).ToList();
            Session["DriverList"] = driverList;
            BuildControls();
        }

        void add_Driver(object sender, ImageClickEventArgs e)
        {
            bool err = false;
            var tb1 = ((TextBox)tZone.FindControl("B")).Text.Trim();
            if (string.IsNullOrEmpty(tb1) || tb1.Equals("Last Name"))
                err = Err("Error: You must have a Last Name.");
            var tb2 = ((TextBox)tZone.FindControl("C")).Text.Trim();
            if (string.IsNullOrEmpty(tb2) || tb2.Equals("First Name"))
                err = Err("Error: You must have a First Name.");
            if (!err)
            {
                driverList.Add(new string[] { ((DropDownList)tZone.FindControl("A")).SelectedValue, tb1, tb2, ((DropDownList)tZone.FindControl("D")).SelectedValue });
                driverList = driverList.OrderBy(q => int.Parse(q[0])).ToList();
                Session["DriverList"] = driverList;
                BuildControls();
            }
        }

        private string[] Badges() { return new string[] { "Bobcat", "Tiger", "Wolf", "Bear", "Webelos" }; }
        private string BadgeUrl(string badge) { return string.Format("~/Images/Badges/Badge_{0}_1200.png", badge); }
        private bool Err(string err) { ErrZone.Controls.Add(new LiteralControl("<span style=\"font-weight: bold; color: red;\">" + err + "</span><br />")); return true; }
    }
}