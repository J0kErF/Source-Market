using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.FIRST
{
    public partial class registration : System.Web.UI.Page
    {
        public string status = "pending";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null) { }
            else
            {

                if (App_Code.ClassUSERS.GetBY(Session["Email"].ToString(), "status").ToLower().Trim() == "admin")
                {
                    AdminPanel.Visible = true;
                    TextBoxjoindate.ReadOnly = true;
                    if (Request.QueryString["email"] != null)
                    {
                        if (!IsPostBack)
                        {
                            filltextboxes();
                        }
                        AdminPanel.Visible = true;
                        UpdateBTN.Visible = true;
                        signupBTN.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("catalog-page.aspx");
                }
            }
        }
        public void filltextboxes()
        {
            string email = Request.QueryString["email"];
            TextBoxjoindate.Text = App_Code.ClassUSERS.GetUser(email).joindate;
            TextBoxstatus.Text = App_Code.ClassUSERS.GetUser(email).status;
            NameTB.Text = App_Code.ClassUSERS.GetUser(email).fullname;
            PasswordTB.Text = App_Code.ClassUSERS.GetUser(email).password;
            PasswordTB.Attributes.Add("type", "text");
            EmailTB.Text = email;
            EmailTB.ReadOnly = true;
            string pn = App_Code.ClassUSERS.GetBY(email, "PhoneNumber");
            PhoneNumberTB.Text = pn;

        }

        protected void signupBTN_Click(object sender, EventArgs e)
        {
           
            if (Request.QueryString["email"] != null && App_Code.ClassUSERS.GetUser(Request.QueryString["email"]).status == "admin")
            {
                status = TextBoxjoindate.Text;
            }
            if (NameTB.Text.Trim() == "" || EmailTB.Text.Trim() == "" || PasswordTB.Text.Trim() == "") { /**/}
            else
            {
                if (App_Code.ClassUSERS.DoesEmailExist(EmailTB.Text.Trim())) {/**/ }
                else
                {

                    com.somee.memailswebservicey.WebServiceMSYEmailSys emailSys = new com.somee.memailswebservicey.WebServiceMSYEmailSys();
                    Session["CODE"] = emailSys.SendActiveationCode("{33126FA1-9A31-43A3-BB96-BE89F1D298E5}", "emailverifybymsy@gmail.com", "Emailverify2002", EmailTB.Text.Trim(),"SOURCE MARKET").ToString();
                    App_Code.ClassUSERS @user = new App_Code.ClassUSERS(EmailTB.Text.Trim(), NameTB.Text, PhoneNumberTB.Text, PasswordTB.Text, status, DateTime.Now.ToString());
                    Session["USER"] = @user;
                    Response.Redirect("activation.aspx");
                }
                /**/
            }
        }

        protected void UpdateBTN_Click(object sender, EventArgs e)
        {
            if (NameTB.Text.Trim() == "" || PasswordTB.Text.Trim() == "") { /**/}
            App_Code.ClassUSERS.Update(Request.QueryString["email"], NameTB.Text, PhoneNumberTB.Text, PasswordTB.Text, TextBoxstatus.Text, TextBoxjoindate.Text);
        }
    }
}