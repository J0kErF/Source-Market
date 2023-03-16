using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.USERAREA
{
    public partial class pendings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DATAVIEW.ActiveViewIndex = 0;
        }

        protected void DTUSERS_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Admin")
                App_Code.ClassUSERS.edit(e.CommandArgument.ToString(), "admin", "Status");

            if (e.CommandName == "Pending")
                App_Code.ClassUSERS.edit(e.CommandArgument.ToString(), "pending", "Status");

            if (e.CommandName == "Active")
                App_Code.ClassUSERS.edit(e.CommandArgument.ToString(), "active", "Status");
            DTUSERS.DataBind();
        }

        protected void LBSELECT_Click(object sender, EventArgs e)
        {
            if (DDLTablName.SelectedValue == "USERS")
                DATAVIEW.ActiveViewIndex = 0;
            if (DDLTablName.SelectedValue == "Product")
                DATAVIEW.ActiveViewIndex = 1;
        }

        protected void dlProducts_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Pending")
                App_Code.ClassPRODUCTS.edit(e.CommandArgument.ToString(), "pending", "state");

            if (e.CommandName == "Active")
                App_Code.ClassPRODUCTS.edit(e.CommandArgument.ToString(), "active", "state");
            dlProducts.DataBind();
            DATAVIEW.ActiveViewIndex = 1;
        }
    }
}