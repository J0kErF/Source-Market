using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.FIRST
{
    public partial class product_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null) Response.Redirect("catalog-page.aspx");
            if (App_Code.ClassPRODUCTS.GetProduct(Request.QueryString["ID"]).state == "pending")
                if (!GetUserValidityForPending())
                {
                    Response.Redirect("catalog-page.aspx");
                }
            specificationslabel.Text = SourceMarket.App_Code.ClassPRODUCTS.GetSpecificationsAsHTML(Request.QueryString["ID"].ToString());
            LabelDescription.Text = App_Code.ClassPRODUCTS.GetBY(Request.QueryString["ID"].ToString(), "description");

        }
        public bool GetUserValidityForPending()
        {
            if (Session["Email"] == null) return false;
            string user = Session["Email"].ToString();
            if (App_Code.ClassUSERS.GetUser(Session["Email"].ToString()).status == "admin")
                return true;
            if (App_Code.ClassPRODUCTS.GetProduct(Request.QueryString["ID"]).Email == Session["Email"].ToString())
                return true;
            return false;
        }
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "productpage")
            { Response.Redirect("product-page.aspx?ID=" + e.CommandArgument.ToString()); }
        }

        protected void AddToCart_ServerClick(object sender, EventArgs e)
        {
            if (Session["Email"] == null)
            {
                string message = "To add to cart a product you should login";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", App_Code.ClassGlobalFunq.GetAlert(message));
            }
            else
            {
                if (App_Code.ClassCart.isaddedtocart(Session["Email"].ToString(), Request.QueryString["ID"]) || App_Code.ClassDeals.isDealed(Session["Email"].ToString(), Request.QueryString["ID"]))
                {
                    string message = "sorry but this item already added to cart or already bought";

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", App_Code.ClassGlobalFunq.GetAlert(message));
                }
                else
                {
                    App_Code.ClassCart.AddToCart(Session["Email"].ToString(), Request.QueryString["ID"].ToString());
                    Response.Redirect("shopping-cart.aspx");
                }
            }
        }

        protected void WriteAReview_Click(object sender, EventArgs e)
        {
            if (Session["Email"] == null)
            {
                string message = "To write a review you should login";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", App_Code.ClassGlobalFunq.GetAlert(message));
            }
            else
            {
                string SQL = "INSERT INTO [reviews] ([title], [review], [time], [EmailID], [PID])";
                SQL = SQL + "VALUES ('" + ReviewTitle.Text + "','" + ReviewBody.Text + "',#" + DateTime.Now.ToString() + "#,'" + Session["Email"].ToString() + "','" + Request.QueryString["ID"] + "')";
                App_Code.ClassGlobalFunq.IUDataWithcustomsql(SQL);
                Reviewsrepeater.DataBind();
            }
        }
    }
}