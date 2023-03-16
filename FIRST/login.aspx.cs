using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        
            if (Session["Email"] == null) {
            }
            if(Session["Email"]!=null)
            {
                Response.Redirect("catalog-page.aspx");
            }
        }

        protected void loginBTN_Click(object sender, EventArgs e)
        {
      

            if ((App_Code.ClassUSERS.GetBY(EmailTB.Text.Trim(), "Password")) == PasswordTB.Text)
            {
                Session["Email"] = EmailTB.Text.Trim();
               Response.Redirect("~/USERAREA/Dashboard.aspx");
               

            }
        }
        
    }
}