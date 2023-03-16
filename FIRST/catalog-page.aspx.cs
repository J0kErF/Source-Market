using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.FIRST
{
    public partial class catalog_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                catalogdatasource.SelectCommand = "SELECT * FROM [Product]  WHERE [state]='active' ORDER BY [downloadcount] DESC, [addeddate] DESC, [price] ";   
            }
        }
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if(e.CommandName== "productpage")
            { Response.Redirect("product-page.aspx?ID="+e.CommandArgument.ToString()); }
        }
        protected void ApplyButton_Click(object sender, EventArgs e)
        {
            string SQL = "SELECT * FROM [Product] WHERE [state]='active'";
            if (byRBL.SelectedItem != null)
            {
                if (byRBL.SelectedItem.Value == "price")
                {
                    SQL+=" ORDER BY [price]";
                    
                }
                if (byRBL.SelectedItem.Value == "time")
                {
                    SQL += " ORDER BY [addeddate] DESC";
                   
                }
                if (byRBL.SelectedItem.Value == "popularity")
                {
                    SQL += " ORDER BY [downloadcount] DESC";
                    
                }
            }
            catalogdatasource.SelectCommand = SQL;
        }
        protected void ResetButton_Click(object sender, EventArgs e)
        {
            catalogdatasource.SelectCommand = "SELECT * FROM [Product] WHERE [state]='active' ORDER BY [downloadcount] DESC, [addeddate] DESC, [price]";
            
            byRBL.SelectedValue = null;
        }

    }
}