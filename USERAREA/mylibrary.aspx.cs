using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.USERAREA
{
    public partial class mylibrary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataList1.DataSource = GetData();
                DataList1.DataBind();
            }
        }
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "download")
            {
                Response.Redirect(e.CommandArgument.ToString());
            }
        }
        public DataTable GetData()
        {
            DataTable Final = new DataTable();
            Final.Columns.Add("Pid", typeof(string));
            Final.Columns.Add("Ptitle", typeof(string));
            Final.Columns.Add("Spath", typeof(string));
            DataTable Deals = App_Code.ClassDeals.GetDealsTo(Session["Email"].ToString());
            if (Deals != null)
                foreach (DataRow row in Deals.Rows)
                {
                    DataRow rOw = Final.NewRow();
                    rOw["Pid"] = row["ProductID"].ToString();
                    rOw["Ptitle"] = App_Code.ClassPRODUCTS.GetBY(row["ProductID"].ToString(), "title");
                    rOw["Spath"] = App_Code.ClassSources.GetBy(row["SourceID"].ToString(), "FilePath");
                    Final.Rows.Add(rOw);
                }
            return Final;
        }
    }
}