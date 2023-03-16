using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.FIRST
{
    public partial class forgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                panelNewPassword.Visible = false;
            }
        }

        protected void ResetBTN_Click(object sender, EventArgs e)
        {
            try {             if (App_Code.ClassUSERS.DoesEmailExist(EmailTB.Text.Trim()) == true)
            {
                panelNewPassword.Visible = true;
                com.somee.memailswebservicey.WebServiceMSYEmailSys emailSys = new com.somee.memailswebservicey.WebServiceMSYEmailSys();
                Session["RanPass"] = emailSys.SendForgotPassword("{33126FA1-9A31-43A3-BB96-BE89F1D298E5}", "emailverifybymsy@gmail.com", "Emailverify2002", EmailTB.Text, 6, "SOURCE MARKET");
            }
            else
            {
                string message = "something went wrong make sure if the info are correct";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", App_Code.ClassGlobalFunq.GetAlert(message));
            }
            }
            catch (Exception ex)
            {
                App_Code.ClassGlobalFunq.IUDataWithcustomsql("INSERT INTO [Errors] ([PageURL],[FuncName],[FuncLine],[ExTime],[ExMessage],[status]) VALUES ([frogotPassword.aspx],[ResetBTN_Click],[20],[" + DateTime.Now.ToString() + "],[" + ex.Message + "],[N/A])");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", App_Code.ClassGlobalFunq.GetAlert(" something went wrong\ntry again later. "));
            }
        }

        protected void ChangeBTN_Click(object sender, EventArgs e)
        {
            try { 
            if (Session["RanPass"].ToString() == "-flase-" || PasswordTB.Text != Session["RanPass"].ToString())
            {
                string message = "something went wrong make sure if the info are correct";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", App_Code.ClassGlobalFunq.GetAlert(message));
            }
            else
            {
                App_Code.ClassUSERS.edit(EmailTB.Text, TextBoxNewPassword.Text, "Password");
                string message = "Password Updated Successfully";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", App_Code.ClassGlobalFunq.GetAlert(message));
            }
            }
            catch (Exception ex)
            {
                App_Code.ClassGlobalFunq.IUDataWithcustomsql("INSERT INTO [Errors] ([PageURL],[FuncName],[FuncLine],[ExTime],[ExMessage],[status]) VALUES ([forgotPassword.aspx],[changeBTN_Click],[40],[" + DateTime.Now.ToString() + "],[" + ex.Message + "],[N/A])");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", App_Code.ClassGlobalFunq.GetAlert(" something went wrong\ntry again later. "));
            }
        }
    }
}