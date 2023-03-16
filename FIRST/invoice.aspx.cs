using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace SourceMarket.FIRST
{
    public partial class invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null /*)//*/|| App_Code.ClassInvoices.GetBy(Request.QueryString["ID"], "Email") != Session["Email"].ToString())
                HTMLTABLE.Text = "Sorry there is an error ocurred \nLooks like the Url format is wrong";

            else
                HTMLTABLE.Text = App_Code.ClassInvoices.GetBy(Request.QueryString["ID"], "HTMLSource");
        }
        protected void DownloadInvoice_Click(object sender, ImageClickEventArgs e)
        {
            exportpdf();
        }
        private void exportpdf()
        {
            try { 
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=OrderInvoice.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.Write(App_Code.ClassInvoices.GetBy(Request.QueryString["ID"], "HTMLSource"));
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            }
            catch (Exception ex)
            {
                App_Code.ClassGlobalFunq.IUDataWithcustomsql("INSERT INTO [Errors] ([PageURL],[FuncName],[FuncLine],[ExTime],[ExMessage],[status]) VALUES ([invoice.aspx],[exportpdf],[28],[" + DateTime.Now.ToString() + "],[" + ex.Message + "],[N/A])");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", App_Code.ClassGlobalFunq.GetAlert(" something went wrong\ntry again later. "));
            }
        }


    }
}