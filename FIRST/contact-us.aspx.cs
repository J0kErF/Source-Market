using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.FIRST
{
    public partial class contact_us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendBTN_Click(object sender, EventArgs e)
        {
            if (NameTB.Text.Trim() == "" || SubjectTB.Text.Trim() == "" || NameTB.Text.Trim() == "" || EmailTB.Text.Trim() == "" || MessageTB.Text.Trim() == "")
            {
                Label1.Text = "";
            }
            else
            {
                string
                    name = NameTB.Text,
                    subject = SubjectTB.Text,
                    email = EmailTB.Text,
                    message = MessageTB.Text;
                string date = DateTime.Now.ToString();

                App_Code.ClassCONTACTUS.Insert(name, subject, email, message, date);
            }
        }
    }
}