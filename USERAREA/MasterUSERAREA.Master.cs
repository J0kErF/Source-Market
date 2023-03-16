using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.USERAREA
{
    public partial class MasterUSERAREA : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null)
            { Response.Redirect("~/FIRST/index.aspx"); }
            else
            {
                countlbl.Text = App_Code.ClassGlobalFunq.statusnotificationscount(Session["Email"].ToString(), "unseen").ToString();
                    HTMLNOTIFICATIONS.Text = App_Code.ClassGlobalFunq.HTMLnotificationMIN(Session["Email"].ToString());
            }

        }
       

        protected void ShowAllALerts_Click(object sender, EventArgs e)
        {
            Response.Redirect("alerts.aspx");
        }
        protected void LogOutbtn_Click(object sender, EventArgs e)
        {
            Session["Email"] = null;
            Response.Redirect("~/FIRST/login.aspx");
        }
    }
}