using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket
{
    public partial class activation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER"] == null)
            { Response.Redirect("login.aspx"); }
        }

        protected void ActivateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (codeTB.Text == Session["code"].ToString())
                {
                    App_Code.ClassUSERS.Insert(((App_Code.ClassUSERS)(Session["USER"])).email, ((App_Code.ClassUSERS)(Session["USER"])).fullname, ((App_Code.ClassUSERS)(Session["USER"])).phonenumber, ((App_Code.ClassUSERS)(Session["USER"])).password, ((App_Code.ClassUSERS)(Session["USER"])).status, ((App_Code.ClassUSERS)(Session["USER"])).joindate);
                    Response.Redirect("login.aspx");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", App_Code.ClassGlobalFunq.GetAlert(" wrong code "));
                }
            }
            catch (Exception ex)
            {
                App_Code.ClassGlobalFunq.IUDataWithcustomsql("INSERT INTO [Errors] ([PageURL],[FuncName],[FuncLine],[ExTime],[ExMessage],[status]) VALUES ([activation.aspx],[ActivateBTN_Click],[19],[" + DateTime.Now.ToString() + "],[" + ex.Message + "],[N/A])");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", App_Code.ClassGlobalFunq.GetAlert(" something went wrong\ntry again later. "));
            }
        }

    }
}