using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.FIRST
{
    public partial class payment_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Email"] == null) Response.Redirect("login.aspx");
            if (App_Code.ClassUSERS.GetBY(Session["Email"].ToString(), "status") == "deleted" || App_Code.ClassUSERS.GetBY(Session["Email"].ToString(), "status") == "pending") { Response.Redirect("USERAREA/error.aspx?ID=INVALID_USER"); };
            Sum.Text = App_Code.ClassCart.GetTotal(Session["Email"].ToString()).ToString();
            if (Convert.ToInt32(Sum.Text) == 0)
                Response.Redirect("catalog-page.aspx");
            /* VISA DETAILS */

            App_Code.Classvisas visa = App_Code.Classvisas.GetDefault(Session["email"].ToString());
            TextBoxNum.ReadOnly = true;
            TextBoxCVC.ReadOnly = true;
            TextBoxHName.ReadOnly = true;
            TextBoxyear.ReadOnly = true;
            TextBoxmonth.ReadOnly = true;
            if (visa != null)
            {
                TextBoxNum.Text = " " + visa.num;
                TextBoxCVC.Text = " " + visa.cvc;
                TextBoxHName.Text = " " + visa.HName;
                TextBoxyear.Text = " " + visa.exdate.Substring(3);
                TextBoxmonth.Text = " " + visa.exdate.Substring(0, 2);
            }
            else
            {
                //modal no credit card detected
            }
            
        }

        protected void ButtonProceed_Click(object sender, EventArgs e)
        {
            Make_The_Deals();
            Repeater1.DataBind();
        }
        public bool checkdate()
        {
            if (DateTime.Compare(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), new DateTime(Convert.ToInt32(TextBoxyear.Text.Trim()), Convert.ToInt32(TextBoxmonth.Text.Trim()), 1)) < 0) { return true; }
            return false;
        }

        public bool checkvisa()
        {
            string visanum = TextBoxNum.Text.Trim();
            if (!double.TryParse(visanum, out double o)) return false;
            if (visanum.Length != 16) return false;
            return true;
        }
        public void Make_The_Deals()
        {
            try { 
            List<string> ts = new List<string>(); int x = 0;
            foreach (RepeaterItem item in Repeater1.Items)
            {
                Label ProductID = (Label)item.FindControl("ProductID");
                string PID = ProductID.Text;
                string PS = App_Code.ClassPRODUCTS.GetBY(PID, "Email");
                string PB = Session["Email"].ToString();
                string Dt = DateTime.Now.ToString();
                string SV = App_Code.Classvisas.GetDefault(PS).num;
                string BV = TextBoxNum.Text.Trim();
                ts.Add(App_Code.ClassDeals.add_deal(PS, PB, Dt, SV, BV, PID));
                App_Code.ClassCart.Remove(PID, Session["Email"].ToString());
                x++;

            }
            string source = App_Code.ClassGlobalFunq.create_invoice_HTMLTABLE(ts,Session["Email"].ToString());
            string ID = App_Code.ClassInvoices.insert(Session["Email"].ToString(), DateTime.Now.ToString(), source);
            Response.Redirect("invoice.aspx?ID=" + ID.Trim() + "");
            }
            catch (Exception ex)
            {
                App_Code.ClassGlobalFunq.IUDataWithcustomsql("INSERT INTO [Errors] ([PageURL],[FuncName],[FuncLine],[ExTime],[ExMessage],[status]) VALUES ([paymentpage.aspx],[Make_The_Deal],[62],[" + DateTime.Now.ToString() + "],[" + ex.Message + "],[N/A])");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", App_Code.ClassGlobalFunq.GetAlert(" something went wrong\ntry again later. "));
            }
        }

    }
}