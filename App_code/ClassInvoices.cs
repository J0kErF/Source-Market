using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SourceMarket.App_Code
{
    public class ClassInvoices
    {
        public static string ID, Email, DTime, HTMLSource;
        public ClassInvoices() { }
        public static string insert(string Email,string DTime, string HTMLSource)
        {
            string SQL = "INSERT INTO [Invoices] ([Email],[DTime],[HTMLSource])";
            SQL = SQL + "VALUES ('{0}',#{1}#,'{2}')";
            SQL = string.Format(SQL, Email, DTime, HTMLSource);
            Dbase.ChangeTable(SQL);
            string SQL1 = "SELECT * FROM [Invoices] WHERE Email='" + Email + "' AND DTime=#" + DTime + "# AND HTMLSource='" + HTMLSource + "'";
            DataTable dt = Dbase.SelectFromTable(SQL1);
            return dt.Rows[0]["ID"].ToString();

        }
        public static string GetBy(string val,string CN)
        {
            string SQL = "SELECT * FROM [Invoices] WHERE [ID]=" + val + "";
            DataTable dt = Dbase.SelectFromTable(SQL);
            if(dt.Rows == null)
            {
                return "";
            }
            return dt.Rows[0][CN].ToString();
        }
        public static DataTable GetInvoices()
        {
            string SQL = "SELECT * FROM [Invoices]";
            DataTable dt = Dbase.SelectFromTable(SQL);
            return dt;
        }
    }
}