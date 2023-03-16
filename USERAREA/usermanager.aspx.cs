using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.USERAREA
{
    public partial class usermanager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void Add_Data()
        {
            string Data = "<table><tr><td>Email</td><td>Approve</td><td>delete</td></tr>";
            DataTable dt = App_Code.ClassUSERS.GetUsers();
            foreach(DataRow row in dt.Rows)
            {
                if(row["status"]=="Pending")
                {
                    Data += "<tr>";
                    Data += "<td>";
                    Data += row["Email"];
                    Data += "</td>";
                    Data += "<td>";
                    Data += "<asp:LinkButton ID=\""+row["Email"]+"\" runat=\"server\" OnClick=\"AppoveUser("+row["Email"]+")\"></asp:LinkButton>";
                    Data += "</td>";
                    Data += "</tr>";
                }
            }
           
        }
        protected void Approve(string Email)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", App_Code.ClassGlobalFunq.GetAlert("Approved"));
        }

        protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {

        }
    }
}