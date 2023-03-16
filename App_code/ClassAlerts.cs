using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SourceMarket.App_Code
{
    public class ClassAlerts
    {
        public string ID, title, From, To, alerttime, status, message;

        public static DataTable GetAllertsmin(string email)
        {
            string SQL = "SELECT * FROM [alerts] WHERE [To]='"+email+"' ORDER BY [alerttime] DESC";
            DataTable dt = Dbase.SelectFromTable(SQL);
            if (dt.Rows.Count == 0)
                return null;
            return dt;
        }
        public static string GetAllert(string ID,string CN)
        {
            string SQL = "SELECT * FROM [alerts] WHERE [ID]=" + ID ;
            DataTable dt = Dbase.SelectFromTable(SQL);
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0][CN].ToString();
        }
        public static DataTable GetNotificationalerts(string email)
        {
            string SQL = "SELECT * FROM [alerts] WHERE [To]='" + email + "' ORDER BY [alerttime] DESC";
            DataTable dt = Dbase.SelectFromTable(SQL);
            if (dt.Rows.Count == 0)
                return null;
            if (dt.Rows.Count <= 4)
                return dt;
            return dt.Rows.Cast<DataRow>().Take(4).CopyToDataTable();
        }
        public static DataTable GetAlerts()
        {
            string SQL = "SELECT * FROM [alerts]";
            DataTable dt = Dbase.SelectFromTable(SQL);
            return dt;
        }
        public static void AddAlert(string title,string From, string To, string alerttime, string status, string message)
        {
            string SQL = "INSERT INTO [alerts] ([title], [From], [To], [alerttime], [status], [message])";
            SQL = SQL + "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')";
            SQL = string.Format(SQL, title, From, To, alerttime, status,message);
            Dbase.ChangeTable(SQL);
        }
    }
}