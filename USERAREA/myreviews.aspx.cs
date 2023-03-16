using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.USERAREA
{
    public partial class myreviews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Reviewsrepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName=="Delete")
            {
                App_Code.ClassGlobalFunq.IUDataWithcustomsql("DELETE * FROM [reviews] WHERE [ID]=" + e.CommandArgument);
            }
        }
    }
}