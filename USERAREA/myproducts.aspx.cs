using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.USERAREA
{
    public partial class myproducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null) { Response.Redirect("~/FIRST/login.aspx"); }
            if (!IsPostBack)
            {
                catalogdatasource.SelectCommand = "SELECT * FROM [Product] WHERE [Email]='"+Session["Email"].ToString()+"' ORDER BY [downloadcount] DESC, [addeddate] DESC, [price] ";
            }

        }
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "productpage")
            { Response.Redirect("~/FIRST/product-page.aspx?ID=" + e.CommandArgument.ToString()); }
            if(e.CommandName == "Edit")
            { Response.Redirect("NEProduct.aspx?ID="+e.CommandArgument.ToString()); }
            if(e.CommandName == "Delete")
            {
                App_Code.ClassPRODUCTS.delete(e.CommandArgument.ToString());
                catalogdatasource.SelectCommand = "SELECT * FROM [Product] WHERE [Email]='" + Session["Email"].ToString() + "' ORDER BY [downloadcount] DESC, [addeddate] DESC, [price] ";
                DataList1.DataBind();
            }
        }
    }
}