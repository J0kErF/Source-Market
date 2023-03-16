using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SourceMarket.App_Code
{
    public class Classvisas
    {
        public string num, cvc, exdate, EmailID, HName, status, IsDefault;
        public Classvisas() { }
        public Classvisas(string num, string cvc, string exdate, string EmailID, string HName, string status, string IsDefault)
        {
            this.num = num;
            this.cvc = cvc;
            this.exdate = exdate;
            this.EmailID = EmailID;
            this.HName = HName;
            this.status = status;
            this.IsDefault = IsDefault;
        }
        public static Classvisas GetDefault(string EmailID)
        {
            string myQuery = "SELECT * FROM [VISAS] WHERE [EmailID] = '" + EmailID + "' AND [IsDefault]='true' ";
            DataTable dt = Dbase.SelectFromTable(myQuery);
            if (dt.Rows.Count == 0)
                return null;
            return new Classvisas(dt.Rows[0]["num"].ToString(), dt.Rows[0]["cvc"].ToString(), dt.Rows[0]["exdate"].ToString(), dt.Rows[0]["EmailID"].ToString(), dt.Rows[0]["HName"].ToString(), dt.Rows[0]["status"].ToString(), dt.Rows[0]["IsDefault"].ToString());
        }
        public static Classvisas GetbyID(string num)
        {
            string myQuery = "SELECT * FROM [VISAS] WHERE [num] = '" + num + "' ";
            DataTable dt = Dbase.SelectFromTable(myQuery);
            if (dt.Rows.Count == 0)
                return null;
            
            return new Classvisas(dt.Rows[0]["num"].ToString(), dt.Rows[0]["cvc"].ToString(), dt.Rows[0]["exdate"].ToString(), dt.Rows[0]["EmailID"].ToString(), dt.Rows[0]["HName"].ToString(), dt.Rows[0]["status"].ToString(), dt.Rows[0]["IsDefault"].ToString());
        }
        public static string Difference(string num, string cvc, string exdate, string EmailID, string HName)
        {


            if (GetbyID(num) == null) { return "Not Exists"; }
            string[] Differnts = GetDifferent(GetbyID(num), cvc, exdate, EmailID, HName);
            if (Differnts == null)
                return "No Difference";
            if (Differnts[3] != null)
                return "Email ID";
            if (Differnts[0] != null)
                return "Holder Name";
            if (Differnts[1] != null)
                return "CVC";
            if (Differnts[2] != null)
                return "Expiration Date";
            
            return "No Difference";


        }
        public static string[] GetDifferent(Classvisas visa, string cvc, string exdate, string EmailID, string HName)
        {
            string[] compare = new string[4];
            if (visa.HName.ToLower().Trim() != HName.ToLower().Trim()) compare[0] = "HName";
            if (visa.cvc.Trim() != cvc.Trim()) compare[1] = "cvc";
            if (visa.exdate.Trim() != exdate.Trim()) compare[2] = "exdate";
            if (visa.EmailID.ToLower().Trim() != EmailID.ToLower().Trim()) compare[3] = "EmailID";
            return compare;
        }
        public static void Addvisa(string num, string cvc, string exdate, string EmailID, string HName , string status, string IsDefault)
        {
            string SQL = "INSERT INTO [Visas] ([num], [cvc], [exdate], [EmailID], [HName], [status], [IsDefault])";
            SQL = SQL + "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
            SQL = string.Format(SQL, num, cvc, exdate, EmailID, HName, status, IsDefault);
            Dbase.ChangeTable(SQL);
        }
        public static void Update(string num, string cvc, string exdate, string EmailID, string HName, string status, string IsDefault)
        {
            string SQL = "UPDATE [Visas] SET [cvc]= '{1}', [exdate] = '{2}', [EmailID] = '{3}', [HName] = '{4}', [status] = '{5}', [IsDefault] = '{6}'";
            SQL += " WHERE [num]= '{0}'";
            SQL = string.Format(SQL, num, cvc, exdate, EmailID, HName, status,IsDefault);
            Dbase.ChangeTable(SQL);
        }   
    }
}