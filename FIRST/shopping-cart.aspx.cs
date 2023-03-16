using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.FIRST
{
    public partial class shopping_cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Total.Text = App_Code.ClassCart.GetTotal(Session["Email"].ToString()).ToString();
        }


        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if(e.CommandName=="delete")
            {
                string PID = ((Label)e.Item.FindControl("PID")).Text;
                string UID = ((Label)e.Item.FindControl("UID")).Text;
                App_Code.ClassCart.Remove(PID,UID);
                DataList1.DataBind();
                Total.Text = App_Code.ClassCart.GetTotal(Session["Email"].ToString()).ToString();
            }
        }

        protected void topayment_Click(object sender, EventArgs e)
        {
            bool visa = true;
            if (App_Code.Classvisas.GetDefault(Session["Email"].ToString()) == null)
                visa = false;
            else
            {
                if (App_Code.Classvisas.GetbyID(App_Code.Classvisas.GetDefault(Session["Email"].ToString()).num).status != "active")
                    visa = false;

                string year = App_Code.Classvisas.GetbyID(App_Code.Classvisas.GetDefault(Session["Email"].ToString()).num).exdate.Substring(3);
                string month = App_Code.Classvisas.GetbyID(App_Code.Classvisas.GetDefault(Session["Email"].ToString()).num).exdate.Substring(0, 2);

                if (DateTime.Compare(new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1), new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)) > 1)
                    visa = false;

            }
            if (App_Code.ClassCart.GetTotal(Session["Email"].ToString()) != 0 && visa)
            {
                Response.Redirect("payment-page.aspx");
            }
            else
            {
                
            }
        }
    }
}