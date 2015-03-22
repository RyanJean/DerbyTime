using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DerbyTimeWeb
{
    public partial class Config : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pack_Num.Text = MySession.Current.pack_Num.ToString();
                pack_Loc.Text = MySession.Current.pack_Loc;
                lanes.SelectedValue = MySession.Current.num_Lanes.ToString();
            }
            btn.ServerClick += btn_ServerClick;
        }

        protected void btn_ServerClick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                MySession.Current.Config(int.Parse(pack_Num.Text), pack_Loc.Text, int.Parse(lanes.SelectedValue));
                Response.Redirect("Default.aspx");
            }
        }
    }
}