using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace SourceMarket.USERAREA
{
    public partial class DataManager : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (App_Code.ClassUSERS.GetUser(Session["Email"].ToString()).status != "admin")
                Response.Redirect("~/FIRST/login.aspx");



            if (!IsPostBack)
            {
                DATAVIEW.ActiveViewIndex = 1;
                FillDropDownListTableName();
                //---------------------------- Fill()
                GenerateTextBoxes(App_Code.ClassCONTACTUS.GetContactus(), false, "");
                fillGridView(App_Code.ClassGlobalFunq.GetDataWithcustomsql("SELECT * FROM [" + DropDownListTableName.SelectedItem.Text + "]"));
            }
        }


        public void FillDropDownListTableName()
        {
            try
            {
                List<string> tables = new List<string>();
                DataTable dt = App_Code.Dbase.MakeConnection().GetSchema("Tables");
                if (App_Code.ClassUSERS.GetUser(Session["Email"].ToString()).status == "admin")
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (!row[2].ToString().Contains("MSys") && row[2].ToString() != "USERS" && row[2].ToString() != "Invoices" && row[2].ToString() != "Product" && row[2].ToString() != "Sources" && row[2].ToString() != "cartproducts")
                            DropDownListTableName.Items.Add((string)row[2]);
                    }
                }
                else
                {
                    DropDownListTableName.Items.Add("");
                    DropDownListTableName.Items.Add("");
                }
            }
            catch (Exception ex)
            {
                App_Code.ClassGlobalFunq.IUDataWithcustomsql("INSERT INTO [Errors] ([PageURL],[FuncName],[FuncLine],[ExTime],[ExMessage],[status]) VALUES ([DataManager.aspx],[FillDropDownListTabeName],[32],[" + DateTime.Now.ToString() + "],[" + ex.Message + "],[N/A])");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", App_Code.ClassGlobalFunq.GetAlert(" something went wrong\ntry again later. "));
            }

        }
        public void GenerateTextBoxes(DataTable dt, bool withdata, string ID)
        {
            EditPanel.Controls.Clear();
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                TextBox textBox = new TextBox();
                Label label = new Label();
                Literal lt = new Literal();
                label.ID = dt.Columns[i].ToString();
                label.Text = dt.Columns[i].ToString() + "  :   ";
                textBox.ID = "TextBox" + dt.Columns[i].ToString();
                textBox.CssClass = "input form-control input-groub";
                if (withdata && ID != "")
                    textBox.Text = dt.Rows[Convert.ToInt32(ID)][dt.Columns[i].ToString()].ToString();

                lt.Text = "<br /><br />";
                EditPanel.Controls.Add(label);
                EditPanel.Controls.Add(textBox);
                EditPanel.Controls.Add(lt);
                EditPanel.Controls.Add(lt);
            }


        }
        public void fillGridView(DataTable dt)
        {
            GridViewAdmin.Columns.Clear();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                BoundField column = new BoundField();
                column.DataField = dt.Columns[i].ToString();
                column.HeaderText = dt.Columns[i].ToString();
                GridViewAdmin.Columns.Add(column);
            }
            GridViewAdmin.DataSource = dt;
            GridViewAdmin.DataBind();
        }
        protected void ButtonGetByID_Click(object sender, EventArgs e)
        {
            DATAVIEW.ActiveViewIndex = 0;
            string Row_num = Get_Row_Num(App_Code.ClassGlobalFunq.GetDataWithcustomsql("SELECT * FROM [" + DropDownListTableName.SelectedItem.Text + "]"), TextBoxID.Text);
            if (float.TryParse(TextBoxID.Text, out float result))
                GenerateTextBoxes(App_Code.ClassGlobalFunq.GetDataWithcustomsql("SELECT * FROM [" + DropDownListTableName.SelectedItem.Text + "]"), true, Row_num);
        }
        protected void LBSELECT_Click(object sender, EventArgs e)
        {
            DATAVIEW.ActiveViewIndex = 1;
            fillGridView(App_Code.ClassGlobalFunq.GetDataWithcustomsql("SELECT * FROM [" + DropDownListTableName.SelectedItem.Text + "]"));
        }
        public static string Get_Row_Num(DataTable dt, string val)
        {
            int place = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row[0].ToString() == val)
                    return place.ToString();
                place++;
            }
            return place.ToString();
        }

        protected void BTNdelete_Click(object sender, EventArgs e)
        {
            App_Code.ClassGlobalFunq.GetDataWithcustomsql("DELETE * FROM [" + DropDownListTableName.SelectedItem.Text + "] WHERE [ID]=" + TextBoxID.Text);
            Response.Redirect("DataManager.aspx");
        }
    }
}