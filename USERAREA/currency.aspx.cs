using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SourceMarket.USERAREA
{
    public partial class currency : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Decimal get_val(string FC,string TC,int Y, int M, int D,Decimal AMOUNT)
        {
            Decimal VAL = 0;
            net.kowabunga.currencyconverter.Converter converter = new net.kowabunga.currencyconverter.Converter();
            VAL= converter.GetConversionAmount(FC, TC, new DateTime(Y, M, D), AMOUNT);
            return VAL;
        }

        protected void LBSearch_Click(object sender, EventArgs e)
        {
            string from = DropDownList1.SelectedItem.Text;
            string to = DropDownList2.SelectedItem.Text;
            string Amount = TextBoxAmount.Text;
            
            TextBoxVal.Text = get_val(from, to, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToDecimal(Amount)).ToString();
            App_Code.ClassGlobalFunq.IUDataWithcustomsql("INSERT INTO [History] ([Email], [From],[To],[Amount],[Val],[AddDate]) VALUES ('" + Session["Email"].ToString() + "','" + from + "','" + to + "','" + Amount + "','" + TextBoxVal.Text + "',#" + DateTime.Now.ToString() + "#)");
            GridViewHistory.DataBind();
        }

        protected void ButtonClearHistory_Click(object sender, EventArgs e)
        {
            App_Code.ClassGlobalFunq.IUDataWithcustomsql("DELETE * FROM [History] WHERE [Email] ='"+Session["Email"].ToString()+"'");
            GridViewHistory.DataBind();
        }
    }
}