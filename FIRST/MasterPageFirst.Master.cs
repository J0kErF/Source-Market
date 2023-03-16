using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket
{
    public partial class MasterPageFirst : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null) { }
            else if (Session["Email"] != null) { HLuser.Text = "My Account"; HLuser.NavigateUrl = "~/USERAREA/Dashboard.aspx"; }
        }
    }
}