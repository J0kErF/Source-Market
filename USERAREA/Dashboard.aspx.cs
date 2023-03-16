using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace SourceMarket.USERAREA
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null) Response.Redirect("~/FIRST/login.aspx");
            SetStatus();
            SetBlocks();
            if (App_Code.ClassUSERS.GetUser(Session["Email"].ToString()).status == "admin")
                PanelAdminToolsLinks.Visible = true;
            
        }
        protected void GenerateReport_Click(object sender, EventArgs e)
        {
            //Response.Redirect(this.ResolveClientUrl("~/FIRST/index.aspx"));

            //Response.Redirect("~/FIRST/index.aspx");
        }
        public void SetBlocks()
        {
            Totallbl.Text = App_Code.ClassGlobalFunq.GetEarnings(Session["Email"].ToString()).ToString();
            Dealslbl.Text = (App_Code.ClassDeals.GetDealsFor(Session["Email"].ToString()).Rows.Count + App_Code.ClassDeals.GetDealsTo(Session["Email"].ToString()).Rows.Count).ToString();
            Productslbl.Text = App_Code.ClassPRODUCTS.GetMyProducts(Session["Email"].ToString()).Rows.Count.ToString();
        }
        public void SetStatus()
        {
            string status = App_Code.ClassUSERS.GetBY(Session["Email"].ToString(), "status");
            switch (status)
            {
                case "admin":
                    {
                        Statuslbl.Text = "<div class=\"col-lg-12 mb-4\"><div class=\"card text-white bg-success shadow\"><div class=\"card-body\"><center><p class=\"m-0\">Welcome Admin</p></center></div></div>";
                        break;
                    }
                case "active":
                    {
                        Statuslbl.Text = "<div class=\"col-lg-12 mb-4\"><div class=\"card text-white bg-success shadow\"><div class=\"card-body\"><center><p class=\"m-0\">Active</p><p class=\"text-white-50 small m-0\">Your account is fine</p></center></div></div>";
                        break;
                    }
                case "pending":
                    {
                        Statuslbl.Text = "<div class=\"col-lg-12 mb-4\"><div class=\"card text-white bg-danger shadow\"><div class=\"card-body\"><center><p class=\"m-0\">Pending</p><p class=\"text-white-50 small m-0\">Your account is on hold for admin review</p></center></div></div>";
                        break;
                    }
                default:
                    { 
                        break; 
                    }
            }
            
        }

        protected void AddUserLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FIRST/registration.aspx");
        }

        protected void MyProductsLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("myproducts.aspx");
        }

        protected void CreateProductsLB_Click(object sender, EventArgs e)
        {
            Response.Redirect("neproduct.aspx");
        }

        protected void LinkButtonMyLibrary_Click(object sender, EventArgs e)
        {
            Response.Redirect("mylibrary.aspx");
        }

        protected void LinkButtonMyReviews_Click(object sender, EventArgs e)
        {
            Response.Redirect("myreviews.aspx");
        }

        protected void LinkButtonPendings_Click(object sender, EventArgs e)
        {
            Response.Redirect("pendings.aspx");
        }

        protected void LinkButtonDeals_Click(object sender, EventArgs e)
        {
            Response.Redirect("myDeals.aspx");
        }

        protected void LinkButtonCurrency_Click(object sender, EventArgs e)
        {
            Response.Redirect("currency.aspx");
        }
    }
}