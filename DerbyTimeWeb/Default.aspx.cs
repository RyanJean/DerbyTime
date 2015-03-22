using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DerbyTimeWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btn_conf.ServerClick += btn_conf_ServerClick;
            btn_drvr.ServerClick += btn_drvr_ServerClick;
            btn_race.ServerClick += btn_race_ServerClick;

            btn_conf.Disabled = false;
            btn_drvr.Disabled = false;
            btn_race.Disabled = false;

            if (!MySession.Current.isConfig)
            {
                btn_drvr.Disabled = true;
                btn_race.Disabled = true;
            }
            if (!MySession.Current.isDrivers)
                btn_race.Disabled = true;
            if (MySession.Current.isSchedule)
            {
                btn_conf.Disabled = true;
                btn_drvr.Disabled = true;
            }
        }

        void btn_conf_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Config.aspx");
        }

        void btn_drvr_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Drivers.aspx");
        }

        void btn_race_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("RaceSetup.aspx");
        }
    }
}