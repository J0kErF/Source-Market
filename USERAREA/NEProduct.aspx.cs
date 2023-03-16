using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SourceMarket.USERAREA
{
    public partial class NEProduct : System.Web.UI.Page
    {

        static string filenames = "";
        long length = 0;
        public App_Code.ClassPRODUCTS product = new App_Code.ClassPRODUCTS();
        static string Fname = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"].ToString() == null) Response.Redirect("~/FIRST/login.aspx");


            if (!IsPostBack)
            {
                ProductImage.Attributes.Add("onclick", "document.getElementById('" + FileUploadImage.ClientID + "').click(); return false;");
                LinkButtonProj.Attributes.Add("onclick", "document.getElementById('" + FileUploadProj.ClientID + "').click(); return false;");
                if (Request.QueryString["ID"] == null)
                {
                    PanelEdit.Visible = false;
                    panelNew.Visible = true;
                }
                else
                {
                    if (App_Code.ClassPRODUCTS.GetProduct(Request.QueryString["ID"]) == null) 
                    {

                        //Wrong ID
                        Response.Redirect("~/USERAREA/error.aspx?ID=INVALED_URL");
                    }
                    else
                    {
                        panelNew.Visible = false;
                        PanelEdit.Visible = true;
                        if (App_Code.ClassUSERS.GetUser(Session["Email"].ToString()).status == "admin")
                        {
                            FillTextBoxesForEdit();
                            FillDDL();
                            DDL.Visible = true;

                        }
                        else if(App_Code.ClassPRODUCTS.GetProduct(Request.QueryString["ID"]).Email == Session["Email"].ToString())
                        {
                                FillTextBoxesForEdit();
                        }
                        else
                        {
                            Response.Redirect("~/USERAREA/error.aspx?ID=INVALED_URL");
                        }
                    }
                }

                
               
            }
        }
        public void FillDDL()
        {
            if(App_Code.ClassPRODUCTS.GetProduct(Request.QueryString["ID"]).state =="active")
            {
                DDL.Items.Insert(0, new ListItem("Active", "active"));
                DDL.Items.Insert(1, new ListItem("Pending", "pending"));
            }
            else
            {
                DDL.Items.Insert(0, new ListItem("Pending", "pending"));
                DDL.Items.Insert(1, new ListItem("Active", "active"));
                
            }
        }
        public void FillTextBoxesForEdit()
        {

            TitleTextBox.Text = App_Code.ClassPRODUCTS.GetProduct(Request.QueryString["ID"]).title;
            LabelSpec.Text = App_Code.ClassPRODUCTS.GetProduct(Request.QueryString["ID"]).specifications;
            TextBoxOS.Text = App_Code.ClassPRODUCTS.GetProduct(Request.QueryString["ID"]).OS;
            TextBoxCL.Text = App_Code.ClassPRODUCTS.GetProduct(Request.QueryString["ID"]).codelang;
            TextBoxC.Text = App_Code.ClassPRODUCTS.GetProduct(Request.QueryString["ID"]).category;
            TextBoxDescription.Text = App_Code.ClassPRODUCTS.GetProduct(Request.QueryString["ID"]).description;
            TextBoxPrice.Text = App_Code.ClassPRODUCTS.GetProduct(Request.QueryString["ID"]).price;
            ImagePro.ImageUrl = App_Code.ClassPRODUCTS.GetProduct(Request.QueryString["ID"]).Pic;
            TextBoxInfo.Text = App_Code.ClassPRODUCTS.GetProduct(Request.QueryString["ID"]).info;
            projLinkButton.Visible = true;
            Fname = App_Code.ClassSources.GetBy(App_Code.ClassPRODUCTS.GetProduct(Request.QueryString["ID"]).SourcePath, "FilePath");
            projLinkButton.Text = "DownLoad The latest ver of this project";
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            

            //parameters
            if (TextBoxPrice.Text.Trim() == "")
            {
                //modal

            }
            else
            {
                if (Request.QueryString["ID"] == null)
                {
                    string status = "pending";
                    if (App_Code.ClassUSERS.GetUser(Session["Email"].ToString()).status == "admin")
                        status = "active";
                    App_Code.ClassSources.AddSource(Session["Email"].ToString(), DateTime.Now.ToString(), Fname.Replace("~\\sources\\", ""), length.ToString(), Fname, TextBoxVer.Text, App_Code.ClassGlobalFunq.generateID("Product").ToString());
                    App_Code.ClassPRODUCTS.Insert(ImagePro.ImageUrl.Replace("~","..").Replace("\\","/"), TitleTextBox.Text, TextBoxPrice.Text, TextBoxInfo.Text, TextBoxDescription.Text, LabelSpec.Text, TextBoxOS.Text, TextBoxC.Text, TextBoxCL.Text, Session["Email"].ToString(), status, DateTime.Now.ToString(),"0", getSourceID());
                }
                //view
                MultiViewSteps.ActiveViewIndex = 3;
            }

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (LabelSpec.Text.Trim() == "" || TextBoxOS.Text.Trim() == "" || TextBoxC.Text.Trim() == "" || TextBoxCL.Text.Trim() == "")
            {
                ///modal
            }
            else
            {

                MultiViewSteps.ActiveViewIndex = 2;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (TitleTextBox.Text.Trim() == "" || TextBoxInfo.Text.Trim() == "" || TextBoxDescription.Text.Trim() == "")
            {
                //modal
            }
            else
            {
                product.title = TitleTextBox.Text.Trim();
                product.info = TextBoxInfo.Text.Trim();
                product.description = TextBoxDescription.Text.Trim();
                MultiViewSteps.ActiveViewIndex = 1;
            }
        }

        protected void LinkButton0_Click(object sender, EventArgs e)
        {
            MultiViewSteps.ActiveViewIndex = 0;
        }

     
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (!LabelSpec.Text.Contains(TextBoxName.Text + " "))
                LabelSpec.Text += "<tr><td> " + TextBoxName.Text + " </td><td>" + TextBoxValue.Text + "</td></tr>";
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            LabelSpec.Text = "";
        }

        protected void ButtonUploadProj_Click(object sender, EventArgs e)
        {
            if (FileUploadProj.HasFile)
            {
                if (Path.GetExtension(FileUploadProj.FileName) == ".zip" || Path.GetExtension(FileUploadProj.FileName) == ".rar")
                {
                    string strRealPath = Request.PhysicalApplicationPath;
                    strRealPath += "sources\\";
                    string name = Session["Email"].ToString() + " " + Path.GetFileNameWithoutExtension(FileUploadProj.FileName) + "SourceMarket" + TextBoxVer.Text + DateTime.Now.ToString().Replace("/", "").Replace(":", "") + Path.GetExtension(FileUploadProj.FileName);
                    FileUploadProj.SaveAs(strRealPath + name);
                    ImageProj.ImageUrl = "~\\media\\UPLOADEDSUCCESSFULLY.png";
                    Fname= "~\\sources\\" + name;
                }

            }
        }

        protected void UploadToServerBTN_Click(object sender, EventArgs e)
        {




            if (FileUploadImage.HasFile)
            {
                if (Path.GetExtension(FileUploadImage.FileName) == ".jpg" || Path.GetExtension(FileUploadImage.FileName) == ".png" || Path.GetExtension(FileUploadImage.FileName) == ".svg")
                {
                    string strRealPath = Request.PhysicalApplicationPath;
                    strRealPath += "Images\\";
                    string name = Session["Email"].ToString() + Path.GetFileNameWithoutExtension(FileUploadImage.FileName) + "SourceMarket" + DateTime.Now.ToString().Replace("/", "").Replace(":", "") + Path.GetExtension(FileUploadImage.FileName);
                    FileUploadImage.SaveAs(strRealPath + name);
                    length = new System.IO.FileInfo(strRealPath + name).Length;
                    ImagePro.ImageUrl = "~\\Images\\" + name;
                }
            }


        }

        protected void LBPI_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FIRST/product-page.aspx?ID=" + (App_Code.ClassGlobalFunq.generateID("Product") - 1).ToString());
        }

        public static string getSourceID()
        {
            int count=App_Code.ClassGlobalFunq.GetDataWithcustomsql("SELECT * FROM [Sources]").Rows.Count;
            count = count - 1;
            int max = 0;
            for(int i=0;i<=count;i++)
            {
                if (Convert.ToInt32(App_Code.ClassGlobalFunq.GetDataWithcustomsql("SELECT * FROM [Sources]").Rows[i][0].ToString()) > max)
                    max = Convert.ToInt32(App_Code.ClassGlobalFunq.GetDataWithcustomsql("SELECT * FROM [Sources]").Rows[i][0].ToString());
            }
            return max.ToString();
        }
        protected void UpdateLinkButton_Click(object sender, EventArgs e)
        {

            App_Code.ClassSources.AddSource(Session["Email"].ToString(), DateTime.Now.ToString(), Fname.Replace("~\\sources\\", ""), length.ToString(), Fname, TextBoxVer.Text, Request.QueryString["ID"]);
            App_Code.ClassPRODUCTS.Update(Request.QueryString["ID"],ImagePro.ImageUrl.Replace("~", "..").Replace("\\", "/"), TitleTextBox.Text, TextBoxPrice.Text, TextBoxInfo.Text, TextBoxDescription.Text, LabelSpec.Text, TextBoxOS.Text, TextBoxC.Text, TextBoxCL.Text, DDL.SelectedValue,getSourceID());
            Statuslbl.Text = "<br /><div class=\"col-lg-12 mb-4\"><div class=\"card text-white bg-success shadow\"><div class=\"card-body\"><center><p class=\"m-0\">UPDATED SUCCESSFULLY</p></center></div></div></div>";
        }

        protected void DeleteLinkButton_Click(object sender, EventArgs e)
        {
            App_Code.ClassPRODUCTS.delete(Request.QueryString["ID"]);
            Statuslbl.Text = "<br /><div class=\"col-lg-12 mb-4\"><div class=\"card text-white bg-danger shadow\"><div class=\"card-body\"><center><p class=\"m-0\">DELETED SUCCESSFULLY</p></center></div></div></div>";
        }

        protected void projLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Fname);
        }
    }
}
