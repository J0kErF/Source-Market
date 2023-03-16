using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.USERAREA
{
    public partial class profile : System.Web.UI.Page
    {
        public string email = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null) Response.Redirect("~/FIRST/login.aspx");
            email = Session["Email"].ToString();
            if (Request.QueryString["Email"] != null && App_Code.ClassUSERS.GetBY(Session["Email"].ToString(),"status") == "admin")
                email = Request.QueryString["Email"];
            if (App_Code.Classvisas.GetDefault(email) == null) { }
            else
            {
                FillCreditCardBox();

            }
            FillUserBox();
            if (App_Code.ClassUSERS.GetBY(email, "status") != "admin") { PanelAdminAlerts.Visible = false; }

        }
        protected void ChangePasswordButton_Click(object sender, EventArgs e)
        {

            if (TextBoxOldPassword.Text.Trim() != App_Code.ClassUSERS.GetBY(email, "Password"))
            {
                //modal Wrong Password
            }
            else
            {
                App_Code.ClassUSERS.Update(email, App_Code.ClassUSERS.GetUser(email).fullname, App_Code.ClassUSERS.GetBY(email, "phonenumber"), TextBoxNewPassword.Text.Trim(), App_Code.ClassUSERS.GetUser(email).status, App_Code.ClassUSERS.GetUser(email).joindate);
                //modal Update success
            }
        }
        public void FillUserBox()
        {
            TextBoxEmail.Text = email;
            TextBoxEmail.ReadOnly = true;
            TextBoxFullName.Attributes.Add("PlaceHolder", App_Code.ClassUSERS.GetUser(email).fullname);
            string pn = App_Code.ClassUSERS.GetBY(email, "PhoneNumber");
            TextBoxPhoneNumber.Attributes.Add("PlaceHolder", pn);


        }
        public void FillCreditCardBox()
        {
            VisaNum.Attributes.Add("PlaceHolder", App_Code.Classvisas.GetDefault(email).num);
            HolderName.Attributes.Add("PlaceHolder", App_Code.Classvisas.GetDefault(email).HName);
            CVC.Attributes.Add("PlaceHolder", App_Code.Classvisas.GetDefault(email).cvc);
            ExpirationDate.Attributes.Add("PlaceHolder", App_Code.Classvisas.GetDefault(email).exdate);
        }
        protected void SaveChangesCreditCard_Click(object sender, EventArgs e)
        {
            string num = VisaNum.Text;
            string HName = HolderName.Text;
            string cvc = CVC.Text;
            string ExDate = ExpirationDate.Text;
            if (num.Trim() == "" || HName.Trim() == "" || cvc.Trim() == "" || ExDate.Trim() == "") { /* modal All the cells must be filled*/}


            if (!checkExDate() || !checkVisa() || cvc.Length != 3)
            { //modal wrong number/date/cvc format
            }
            else
                updatedata(num, cvc, ExDate, HName);


        }
        public void updatedata(string num, string cvc, string ExDate, string HName)
        {
            string state = "old", exists = "true";
            if (App_Code.Classvisas.GetDefault(email) == null) { state = "new"; }
            if (App_Code.Classvisas.GetbyID(num) == null) { exists = "false"; }
            if (state == "old")
            {
                if (exists == "false")
                {
                    App_Code.Classvisas.Update(App_Code.Classvisas.GetDefault(email).num, App_Code.Classvisas.GetDefault(email).cvc, App_Code.Classvisas.GetDefault(email).exdate, email, App_Code.Classvisas.GetDefault(email).HName, App_Code.Classvisas.GetDefault(email).status, "false");
                    App_Code.Classvisas.Addvisa(num, cvc, ExDate, email, HName, "active", "true");
                }
                if (exists == "true")
                {
                    if (App_Code.Classvisas.GetbyID(num).EmailID == email)
                    {
                        App_Code.Classvisas.Update(App_Code.Classvisas.GetDefault(email).num, App_Code.Classvisas.GetDefault(email).cvc, App_Code.Classvisas.GetDefault(email).exdate, email, App_Code.Classvisas.GetDefault(email).HName, App_Code.Classvisas.GetDefault(email).status, "false");
                        App_Code.Classvisas.Update(num, cvc, ExDate, email, HName, App_Code.Classvisas.GetbyID(num).status, "true");
                    }
                    else
                    {
                        if (App_Code.Classvisas.GetbyID(num).IsDefault == "false")
                        {
                            App_Code.Classvisas.Update(App_Code.Classvisas.GetDefault(email).num, App_Code.Classvisas.GetDefault(email).cvc, App_Code.Classvisas.GetDefault(email).exdate, email, App_Code.Classvisas.GetDefault(email).HName, App_Code.Classvisas.GetDefault(email).status, "false");
                            App_Code.Classvisas.Update(num, cvc, ExDate, email, HName, App_Code.Classvisas.GetbyID(num).status, "true");
                        }
                        else
                        {
                            //modal this visa is linked to other account
                        }
                    }
                }
            }
            else
            {
                if (exists == "false")
                {
                    App_Code.Classvisas.Addvisa(num, cvc, ExDate, email, HName, "active", "true");
                }
                if (exists == "true")
                {
                    if (App_Code.Classvisas.GetbyID(num).EmailID == email)
                    {
                        App_Code.Classvisas.Update(num, cvc, ExDate, email, HName, App_Code.Classvisas.GetbyID(num).status, "true");
                    }
                    else
                    {
                        //modal this visa is linked to other account
                    }
                }
            }
        }
        public bool checkExDate()
        {
            string year = ExpirationDate.Text.Substring(3);
            string month = ExpirationDate.Text.Substring(0, 2);
            if (DateTime.Compare(new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1), new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)) < 0)
                return false;
            return true;
        }
        public bool checkVisa()
        {
            if (VisaNum.Text.Length != 16) return false;
            return true;
        }
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string fullname = "", PhoneNumber = "";
            if (TextBoxFullName.Text.Trim() == "")
                fullname = TextBoxFullName.Attributes["PlaceHolder"];
            else
                fullname = TextBoxFullName.Text;
            if (TextBoxPhoneNumber.Text.Trim() == "")
                PhoneNumber = TextBoxPhoneNumber.Attributes["PlaceHolder"];
            else
                PhoneNumber = TextBoxPhoneNumber.Text;
            App_Code.ClassUSERS.Update(email, fullname, PhoneNumber, App_Code.ClassUSERS.GetUser(email).password, App_Code.ClassUSERS.GetUser(email).status, App_Code.ClassUSERS.GetUser(email).joindate);

        }
        protected void ButtonShareAlert_Click(object sender, EventArgs e)
        {
                App_Code.ClassAlerts.AddAlert(TextBoxTitle.Text, email, TextBoxTo.Text, DateTime.Now.ToString(), "unseen", TextBoxMessage.Text);
        }
    }
}