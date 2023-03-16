using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.USERAREA
{
    public partial class Alerts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null)
            {
                Response.Redirect("~/First/login.aspx");
            }
            FillGrid();
            if (Request.QueryString["ID"] != null)
            {
                App_Code.ClassGlobalFunq.IUDataWithcustomsql("UPDATE [alerts] SET [status]= 'seen' WHERE [ID]=" + Request.QueryString["ID"]);
            }

            GridViewAlerts.DataBind();
            if (GridViewAlerts.Rows.Count == 0)
            {
                msgLBL.Text = "No Records Found";

            }
            else msgLBL.Text = "";


        }
        public void FillGrid()
        {

            GridViewAlerts.DataSource = null;
            GridViewAlerts.DataBind();
            if (App_Code.ClassUSERS.GetUser(Session["Email"].ToString()).status == "admin")
            {
                if (Request.QueryString["email"] == null && Request.QueryString["ID"] == null)
                {
                    GridViewAlerts.DataSource = App_Code.ClassGlobalFunq.GetDataWithcustomsql("SELECT * FROM [alerts] WHERE [To] = '" + Session["Email"].ToString() + "'  ORDER BY [alerttime] DESC");

                    MultiviewAlerts.ActiveViewIndex = 0;
                }

                else
                {
                    if (Request.QueryString["ID"] == null)
                    {
                        GridViewAlerts.DataSource = App_Code.ClassGlobalFunq.GetDataWithcustomsql("SELECT * FROM [alerts] WHERE [To] ='" + Request.QueryString["Email"].ToString() + "'  ORDER BY [alerttime] DESC");

                        MultiviewAlerts.ActiveViewIndex = 0;
                    }
                    else
                    {
                        fillalert(Request.QueryString["ID"]);
                        MultiviewAlerts.ActiveViewIndex = 1;
                    }
                }
            }
            else
            {

                if (Request.QueryString["ID"] == null)
                {
                    GridViewAlerts.DataSource = App_Code.ClassGlobalFunq.GetDataWithcustomsql("SELECT * FROM [alerts] WHERE [To] ='" + Session["Email"].ToString() + "'  ORDER BY [alerttime] DESC");
                    MultiviewAlerts.ActiveViewIndex = 0;
                }
                else
                {
                    if (Session["Email"].ToString() == App_Code.ClassAlerts.GetAllert(Request.QueryString["ID"], "To"))
                    {
                        fillalert(Request.QueryString["ID"]);

                        MultiviewAlerts.ActiveViewIndex = 1;
                    }
                }

            }
        }
        protected void ButtonClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Alerts.aspx");
        }
        public void fillalert(string AID)
        {
            TextBoxID.Text = AID;

            TextBoxDate.Text = App_Code.ClassAlerts.GetAllert(AID, "alerttime");

            TextBoxSubject.Text = App_Code.ClassAlerts.GetAllert(AID, "title");
            TextBoxMessage.Text = App_Code.ClassAlerts.GetAllert(AID, "message");
            TextBoxFrom.Text = App_Code.ClassAlerts.GetAllert(AID, "From");
        }


        protected void GridViewAlerts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                Response.Redirect("~/USERAREA/Alerts.aspx?ID=" + e.CommandArgument);
            }
        }
    }
}